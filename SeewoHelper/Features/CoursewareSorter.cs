﻿using SeewoHelper.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SeewoHelper.Features
{
    public class CoursewareSorter
    {
        private readonly IEnumerable<SubjectStorageInfo> _subjectStorageInfos;

        private readonly IEnumerable<FileInfo> _files;

        public void Sort()
        {
            foreach (var info in _subjectStorageInfos)
            {
                Sort(info);
            }
        }

        private void Sort(SubjectStorageInfo info)
        {
            var files = new List<FileInfo>();

            foreach (string keyword in info.Keywords)
            {
                var regex = new Regex(keyword);
                files.AddRange(_files.Where(x => regex.IsMatch(x.Name)));
            }

            var processFiles = files.Distinct();

            foreach (var file in processFiles)
            {
                file.MoveTo(IOUtilities.PathAppend(info.Path, file.Name), true);
            }
        }

        public CoursewareSorter(IEnumerable<SubjectStorageInfo> infos, string path)
        {
            _subjectStorageInfos = infos;
            _files = Directory.GetFiles(path).Select(x => new FileInfo(x));
        }
    }
}
