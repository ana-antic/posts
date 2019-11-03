using System;
using System.Collections.Generic;
using System.Text;

namespace PostsTest
{
    class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Post()
        {

        }

        public Post(int id, string title, string author,DateTime date) 
        {
            ID = id;
            Title = title;
            Author = author;
            Date = date;
        }
    }
}
