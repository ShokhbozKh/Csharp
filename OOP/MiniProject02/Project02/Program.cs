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
            int userCount = 100, albumCount = 100, songCount = 1000;

            /*
             * generating users
             */
            var userList = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                userList.Add(new User(i + " login", i + " password"));
            }

            /*
             * generating albums
             */
            var albumList = new List<Album>();
            for (int i = 0; i < 100; i++)
            {
                var album = new Album($"album{i}");
                albumList.Add(album);
            }

            /*
             * generating songs
             */
            var songList = new List<Song>();
            for (int i = 0; i < 1000; i++)
            {
                var user = userList[i % 10];
                var song = new Song(i.ToString(), 3000, user, DateTime.Now);
                songList.Add(song);
                /*
                 * basic association - adding song to album
                 */
                song.Album = albumList[i % 100];
            }

            /*
             * basic association - reassigning songs to other album 
             */
            for (int i = 0; i < 100; i++)
            {
                songList[i].Album = albumList[albumList.Count - 1];
            }

            albumList.ForEach(Console.WriteLine);

            /*
             * attribute association - adding ListenEvents
             */
            foreach (var user in userList)
            {
                for (int i = 0; i < 10; i++)
                {
                    foreach (var song in songList)
                    {
                        ListenEvent.AddListenEvent(user, song);
                    }
                }
            }

            Console.WriteLine($"user listen count: {userList.Average(u => u.ListenEvents.Count)}");
            Console.WriteLine($"song listen count: {songList.Average(s => s.ListenEvents.Count)}");

            /*
             * generating texts:
             */
            var textList = new List<AudioText>();
            for (int i = 0; i < 3000; i++)
            {
                var text = new AudioText
                {
                    Second = i, Text = i.ToString()
                };
                textList.Add(text);
            }

            /*
             * qualified association - adding texts to songs 
             */
            for (int i = 0; i < textList.Count; i++)
            {
                songList[i % songCount].AddText(textList[i]);
            }

            Console.WriteLine(songList[0].Text.Count);

            /*
             * composition - adding reviews to songs
             */
            for (int i = 0; i < songCount * 5; i++)
            {
                Review.CreateReview(songList[i % songCount], userList[i % userCount], i.ToString(), i % 5);
            }
            Console.WriteLine($"{songList[0].Reviews.Count}");
        }
    }
}