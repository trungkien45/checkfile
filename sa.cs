        private static bool CheckPathVaild(string path)
        {
            try
            {
                var s = Path.GetFullPath(path);
                if (CheckHasFileInPath(s))
                {
                    return false;
                }
                s = s.Substring(Path.GetPathRoot(s).Length);
                var s2 = s.Split(Path.DirectorySeparatorChar);
                return s2.All(item => !item.Any(p => Path.GetInvalidFileNameChars().Contains(p)));
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static bool CheckHasFileInPath(string path)
        {
            var s2 = path.Split(Path.DirectorySeparatorChar);
            var s3 = s2[0];
            for (int i = 1; i < s2.Length - 1; i++)
            {
                s3 = Path.Join(s3, s2[i]);
                if (File.Exists(s3))
                {
                    FileAttributes attr = File.GetAttributes(s3);
                    if (!attr.HasFlag(FileAttributes.Directory))
                        return true;
                }
            }
            return false;

        }
        public static bool CheckPathIsFile(string path)
        {
            if (CheckPathVaild(path))
            {
                var s = Path.GetFullPath(path);
                if (!Directory.Exists(s))
                {
                    if (!s.EndsWith(Path.DirectorySeparatorChar))
                    {
                        s = Path.GetFileName(s);
                        return !string.IsNullOrEmpty(s);
                    }
                }
            }
            return false;
        }
        public static bool CheckPathIsDirectory(string path)
        {
            if (CheckPathVaild(path))
            {
                var s = Path.GetFullPath(path);
                if (Directory.Exists(s))
                {
                    return true;
                }
                if (s.EndsWith(Path.DirectorySeparatorChar))
                {
                    return true;
                } 
            }
            return false;
        }
