using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterCloneApp.Models;
using TwitterCloneApp.DataAccess;
using System.Threading.Tasks;

namespace TwitterCloneApp.DataAccess
{
    public class DataAccessLayer
    {
        
        public static async Task<int> createNewUser(person objPerson)
        {
            FSEEntities dbcontest = new FSEEntities();
            dbcontest.people.Add(objPerson);
            return await dbcontest.SaveChangesAsync();
        }

        public static List<person> validateUser(string username, string password)
        {
            FSEEntities dbcontest = new FSEEntities();

            var result = dbcontest.people.Where(x => x.user_id == username && x.password == password );
            return result.ToList();
        }

        public static TweetModel getUserTweets(string username)
        {
            TweetModel tm = new TweetModel();

            using (var db = new FSEEntities())
            {
                var followingUsers = db.followings.Where(x => x.user_id == username).Select(x => x.following_id);
                var userTweets = db.tweets.Where(x => x.user_id == username).ToList();
                var followerTweets = db.tweets.Where(x => followingUsers.Contains(x.user_id)).ToList();
                var allTweets = userTweets.Union(followerTweets).OrderByDescending(x=>x.craeted).ToList();
                tm.no_of_followers = followingUsers.Count();
                tm.no_of_followings = db.followings.Where(x => x.following_id == username).Count();
                tm.no_of_tweets = userTweets.Count();
                tm.tweets = allTweets;
                 
            }

            return tm;
        }

        public static bool saveUserTweet(tweet twmodel)
        {
            bool result = false;
            using(var db = new FSEEntities())
            {
                db.tweets.Add(twmodel);
                db.SaveChanges();
                result = true;
            }

            return result;
        }

        public static bool isUserAvailable(string username)
        {
            bool result = false;
            using (var db = new FSEEntities())
            {
                var isUser = db.people.Where(x => x.user_id == username).Any();
                if(isUser)
                {
                    result = true;
                }
                
            }
            return result;
        }
        public static person getPersonDetails(string username)
        {
            using (var db = new FSEEntities())
            {
                var result = db.people.Where(x => x.user_id == username).FirstOrDefault();
                return result;
            }
        }
        public static bool followUser(string loginUserid, string followUserid)
        {
            bool result = false;
            using (var db = new FSEEntities())
            {
                following following = new following();
                following.user_id = loginUserid;
                following.following_id = followUserid;
                var userTest = db.followings.Where(x => x.user_id == loginUserid && x.following_id == followUserid).Any();
                if (!userTest)
                {
                    db.followings.Add(following);
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
    }
}