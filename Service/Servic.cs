namespace Service
{
    using Classes;
    using System;
    using Repository;
    using System.Collections.Generic;

    public class Servic
    {
        public Repository repository = new Repository();
        public List<Columnname> ReadColumn(string filePath)
        {
            return repository.ReadColumn(filePath);
        }

        public bool WriteFile(MapClass map, string originPath, string targetPath)
        {
            return repository.WtiteFile(map, originPath, targetPath);
        }

        public bool Reader(List<MapClass> maps , string Opath , string Tpath)
        {
            return repository.Reader(maps, Tpath , Opath );
        }
    }
}