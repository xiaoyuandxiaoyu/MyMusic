namespace MyMusic.Services
{
    public class GetMusic
    {
        public List<string> FindFilesWithExtension(string path, string extension)
        {
            List<string> foundFiles = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles("*." + extension); // 获取当前目录下所有指定后缀的文件  

            foreach (FileInfo file in files)
            {
                foundFiles.Add(file.FullName); // 添加到集合中  
            }

            // 递归搜索子目录  
            foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
            {
                foundFiles.AddRange(FindFilesWithExtension(subDir.FullName, extension)); // 递归调用自身来搜索子目录  
            }

            return foundFiles; // 返回找到的所有文件路径列表  
        }
    }
}
