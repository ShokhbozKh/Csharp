using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Schema;

namespace MiniProject01
{
    class Program
    {
        static void Main(string[] args)
        {
            var userList = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                userList.Add(new User(i.ToString() + " login", i.ToString() + " password"));
                Console.Write(new Guid());
            }

            var reviewList = new List<Review>();
            for (int i = 0; i < 2; i++)
            {
                reviewList.Add(new Review
                {
                    Author = userList[i % 10],
                    Rate = i % 10
                });
            }

            var songList = new List<Song>();
            for (int i = 0; i < 1000; i++)
            {
                var user = userList[i % 10];
                songList.Add(new Song(i.ToString(), i * 10, user, DateTime.Now)
                {
                    ListenCount = i
                });
            }

            songList[0].AddReview(reviewList[0]);
            Console.WriteLine(songList[0].Rating);
            songList[0].AddReview(reviewList[1]);
            Console.WriteLine(songList[0].Rating);


            var podcastList = new List<Podcast>();
            for (int i = 0; i < 500; i++)
            {
                var user = userList[i % 10];
                podcastList.Add(new Podcast(i.ToString(), i * 10, user, DateTime.Now)
                {
                    ListenCount = i
                });
            }

            Audio.MaxDuration = 1;

//          serialization
            var fileName = "newFile.data";
            ObjectPlus.SerializeToFile(fileName);
            ObjectPlus.DeserializeFromFile(fileName);
        }
    }
}