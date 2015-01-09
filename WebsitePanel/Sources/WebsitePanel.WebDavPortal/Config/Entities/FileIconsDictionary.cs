﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebsitePanel.WebDavPortal.WebConfigSections;

namespace WebsitePanel.WebDavPortal.Config.Entities
{
    public class FileIconsDictionary : AbstractConfigCollection, IReadOnlyDictionary<string, string>
    {
        private readonly IDictionary<string, string> _fileIcons;

        public FileIconsDictionary()
        {
            DefaultPath = ConfigSection.FileIcons.DefaultPath;
            _fileIcons = ConfigSection.FileIcons.Cast<FileIconsElement>().ToDictionary(x => x.Extension, y => y.Path);
        }

        public string DefaultPath { get; private set; }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _fileIcons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get { return _fileIcons.Count; }
        }

        public bool ContainsKey(string extension)
        {
            return _fileIcons.ContainsKey(extension);
        }

        public bool TryGetValue(string extension, out string path)
        {
            return _fileIcons.TryGetValue(extension, out path);
        }

        public string this[string extension]
        {
            get { return ContainsKey(extension) ? _fileIcons[extension] : DefaultPath; }
        }

        public IEnumerable<string> Keys
        {
            get { return _fileIcons.Keys; }
        }

        public IEnumerable<string> Values
        {
            get { return _fileIcons.Values; }
        }
    }
}