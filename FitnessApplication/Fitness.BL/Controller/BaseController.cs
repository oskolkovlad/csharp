using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Базовый контроллер.
    /// </summary>
    /// <typeparam name="T"> Тип списка данных. </typeparam>
    public abstract class BaseController
    {
        /// <summary>
        /// Сохранение данных.
        /// </summary>
        /// <param name="fileName"> Имя файла для сохранения данных. </param>
        /// <param name="list"> Список данных. </param>
        protected internal virtual void Save<T>(string fileName, T list)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }

        /// <summary>
        /// Получение данных.
        /// </summary>
        /// <param name="fileName"> Имя файла для загрузки данных. </param>
        /// <returns> Список данных. </returns>
        protected internal virtual T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T list)
                {
                    return list;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
