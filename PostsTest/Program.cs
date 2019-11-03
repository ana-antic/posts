using System;

namespace PostsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            Post[] posts = p.CreatePosts();

            for(int i=0;i<10;i++)
                Console.Write("{0} post: Date created, Title, Author: {1}, {2}, {3}\n", i, posts[i].Date, posts[i].Title, posts[i].Author);

            Console.Write("\n\n\nInput the ID of post: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 0 && n < 10)
            {
                var result = p.SearchPost(n, posts);
                DateTime date = result.date;
                Console.Write("\nDetails of post with ID {0}: Date created, Title, Author: {1}, {2}, {3}", n, result.date, result.title, result.author);
            } else Console.Write("\nThere is no post with ID {0}", n);

            posts = p.SortPosts(posts);

            Console.WriteLine("\n\n\nSorted posts by date: \n");
            for (int i = 0; i < 10; i++)
                Console.Write("{0} post: Date created, Title, Author: {1}, {2}, {3}\n", i, posts[i].Date, posts[i].Title, posts[i].Author);
        }

        public Post[] CreatePosts() 
        {
            Random rand = new Random();
            DateTime startDate = new DateTime(2019, 1, 1);
            int range = (DateTime.Today - startDate).Days;

            Post[] posts = new Post[10];

            for (int i = 0; i < posts.Length; i++)
                posts[i] = new Post(i, RandomString(), RandomString(), startDate.AddDays(rand.Next(range)));

            return posts;
        }

        public string RandomString()
        {
            string rand="abcdefghijklmnopqrstuvwxyz";
            Random r = new Random();
            string randS = "";
            for (int i = 0; i < 8; i++)
            {
                randS += rand[r.Next(0, 25)].ToString();
            }
            
            return randS;
        }

        public (string title, string author, DateTime date) SearchPost(int id, Post[] posts) 
        {
            foreach (var p in posts)
            {
                if (p.ID == id)
                {
                    return (p.Title, p.Author, p.Date);
                }
            }

            return (null, null, default(DateTime));
        }

        public Post[] SortPosts(Post[] posts)
        {
            Post pom = new Post();

            for (int i = 1; i <= 10; i++)
                for (int j = 0; j < 10 - i; j++)
                    if (posts[j].Date < posts[j + 1].Date)
                    {
                        pom = posts[j];
                        posts[j] = posts[j + 1];
                        posts[j + 1] = pom;
                    }
            return posts;
        }
    }
}
