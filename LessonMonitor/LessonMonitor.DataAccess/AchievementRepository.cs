using LessonMonitor.Core;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly string path = "../dataAchievement.json";
        public AchievementRepository()
        {
        }
        public void Create(Core.Achievement achievement)
        {
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                fs.WriteLine(JsonConvert.SerializeObject(achievement));
            }                

        }

        public Core.Achievement GetFirst()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var achievement = JsonConvert.DeserializeObject<Core.Achievement>(sr.ReadLine());

                return  achievement;
            }
        }
    }
}
