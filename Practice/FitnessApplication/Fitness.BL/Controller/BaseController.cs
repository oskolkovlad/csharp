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
        //private readonly IDataSaver manger = new DatabaseDataSaver();
        private IDataSaver manger = new SerializeDataSaver();

        /// <summary>
        /// Сохранение данных.
        /// </summary>
        /// <param name="fileName"> Имя файла для сохранения данных. </param>
        /// <param name="list"> Список данных. </param>
        protected void Save<T>(List<T> items) where T: class
        {
            manger.Save(items);
        }

        /// <summary>
        /// Получение данных.
        /// </summary>
        /// <param name="fileName"> Имя файла для загрузки данных. </param>
        /// <returns> Список данных. </returns>
        protected List<T> Load<T>() where T : class
        {
            return manger.Load<T>();
        }
    }
}
