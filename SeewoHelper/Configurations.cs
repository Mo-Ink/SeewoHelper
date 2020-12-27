﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SeewoHelper
{
    internal static class Configurations
    {
        private static readonly string _path = Path.Combine(Application.StartupPath, "Configs");

        public static Configuration<CoursewareSortingInfo> CoursewareSortingInfoConfig = Program.DisposableCollection.Add(new Configuration<CoursewareSortingInfo>("CoursewareSortingInfo", _path, new CoursewareSortingInfo(null, new List<SubjectStorageInfo>())));

        public static Configuration<MonitorableList<Log>> LoggerConfig = Program.DisposableCollection.Add(new Configuration<MonitorableList<Log>>("Logger", _path, new MonitorableList<Log>()));
    }
}
