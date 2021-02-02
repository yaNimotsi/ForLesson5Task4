using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ConsoleApp7
{
    enum ObjectTypes
    {
        folder,
        file
    }
    class Objects
    {
        static string pathObject;
        static string objectType;

        public static string PathObject
        {
            get { return pathObject; }
            set
            {
                pathObject = value;
            }
        }

        public static string ObjectType
        {
            get { return objectType; }
            set { objectType = GetTypeObject(value); }
        }

        public Objects()
        {

        }
        /// <summary>
        /// Определение типа найденного объекта
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string GetTypeObject(string value)
        {
            string extension = Path.GetExtension(value);
            
            if (extension == null) return ObjectTypes.folder.ToString();

            return ObjectTypes.file.ToString();
        }
    }
}
