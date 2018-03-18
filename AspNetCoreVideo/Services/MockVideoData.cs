using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Entities;
using AspNetCoreVideo.Models;

namespace AspNetCoreVideo.Services{
    public class MockVideoData : IVideoData {
        private IEnumerable<Video> _videos;
        public MockVideoData() {
           _videos = new List<Video> {

               new Video { Id = 1, Genre=Genres.Comedy, Title = "Shreck" },
               new Video { Id = 2, Genre=Genres.Comedy, Title = "Despicable me" },
               new Video {Id=3, Genre=Genres.Comedy, Title="Megamind"}
            };
        }

        public void Add(Video video) {
            video.Id = _videos.Max(x => x.Id) + 1;
            (_videos as List<Video>).Add(video);
        }

        public int Commit() {
            return 0;
        }

        public Video Get(int id) {
            return _videos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Video> GetAll() {
            return _videos;
        }

    }
}
