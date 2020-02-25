namespace Interfaces
{
    interface ICar : IObject
    {
        int Speed { get; set; }

        /// <summary>
        /// Выполнить перемещение
        /// </summary>
        /// <param name="distance"> Расстояние </param>
        /// <returns> Время движения (часы) </returns>
        int Move(int distance, int speed);

        /// <summary>
        /// Звуковой сигнал (гудок)
        /// </summary>
        void Beep();
    }
}
