        public static bool CheckPathVaild(string path)
        {
            try
            {
                var s = Path.GetFullPath(path);

                if (!Directory.Exists(path))
                {
                    s = Path.GetFileName(s);
                    return !s.Any(p => Path.GetInvalidFileNameChars().Contains(p));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool CheckPathIsFile(string path)
        {
            if (CheckPathVaild(path))
            {
                var s = Path.GetFullPath(path);
                s = Path.GetFileName(s);
                return !s.Any(p => Path.GetInvalidFileNameChars().Contains(p));
            }
            return false;
        }
   
