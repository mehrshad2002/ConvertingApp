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
    }
}