using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterCloneApp.DataAccess;

namespace TwitterCloneApp.Models
{
    public class TweetModel
    {
        public string username { get; set; }
        public int no_of_followers { get; set; }
        public int no_of_followings { get; set; }
        public int no_of_tweets { get; set; }

        public List<tweet> tweets { get; set; }
    }
}