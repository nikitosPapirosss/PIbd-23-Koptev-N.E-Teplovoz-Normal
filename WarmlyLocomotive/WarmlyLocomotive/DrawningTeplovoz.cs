using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmlyLocomotive
{
    public class DrawningTeplovoz
    {
        /// <summary>
        /// Класс-сущность
        /// </summary>
        public EntityTeplovoz? EntityTeplovoz { get; private set; }
        /// <summary>
        /// Ширина окна
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Левая координата прорисовки автомобиля
        /// </summary>
        private int _startPosX;
        /// <summary>
        /// Верхняя кооридната прорисовки автомобиля
        /// </summary>
        private int _startPosY;
        /// <summary>
        /// Ширина прорисовки автомобиля
        /// </summary>
        private readonly int _teplovozWidth = 105;
        /// <summary>
        /// Высота прорисовки автомобиля
        /// </summary>
        private readonly int _teplovozHeight = 37;
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="bodyColor">Цвет кузова</param>
        /// <param name="additionalColor">Дополнительный цвет</param>
        /// <param name="bodyKit">Признак наличия обвеса</param>
        /// <param name="wing">Признак наличия антикрыла</param>
        /// <param name="sportLine">Признак наличия гоночной полосы</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        /// <returns>true - объект создан, false - проверка не пройдена,
        public bool Init(int speed, double weight, Color bodyColor, Color
        additionalColor, int width, int height)
        {
            // TODO: Продумать проверки
            if (_teplovozWidth > width || _teplovozHeight > height)
            {
                return false;
            }
            else
            {
                _pictureWidth = width;
                _pictureHeight = height;
                EntityTeplovoz = new EntityTeplovoz();
                EntityTeplovoz.Init(speed, weight, bodyColor, additionalColor);
                return true;
            }
        }
        /// <summary>
        /// Установка позиции
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void SetPosition(int x, int y)
        {
            // TODO: Изменение x, y
            if(x<_pictureWidth && y < _pictureHeight && x>15 & y>30)
            {
                _startPosX = x;
                _startPosY = y;
            }
            else
            {
                Random random = new();
                _startPosX = random.Next(10, 100);
                _startPosY= random.Next(100, 150);

            }
        }
        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(DirectionType direction)
        {
            if (EntityTeplovoz == null)
            {
                return;
            }
            switch (direction)
            {
                //влево
                case DirectionType.Left:
                    if (_startPosX - EntityTeplovoz.Step > 0)
                    {
                        _startPosX -= (int)EntityTeplovoz.Step;
                    }
                    break;
                //вверх
                case DirectionType.Up:
                    if (_startPosY - EntityTeplovoz.Step > 0)
                    {
                        _startPosY -= (int)EntityTeplovoz.Step;
                    }
                    break;
                // вправо
                case DirectionType.Right:
                    if (_startPosX + EntityTeplovoz.Step < _pictureWidth-_teplovozWidth)
                    {
                        _startPosX += (int)EntityTeplovoz.Step;
                    }
                    break;
                //вниз
                case DirectionType.Down:
                    if (_startPosY + EntityTeplovoz.Step < _pictureHeight-_teplovozHeight)
                    {
                        _startPosY += (int)EntityTeplovoz.Step;
                    }
                    break;
            }
        }

        public void DrawTransport(Graphics g)
        {
            if (EntityTeplovoz == null)
            {
                return;
            }
            Pen pen = new(Color.Black);
            Brush additionalBrush = new
            SolidBrush(EntityTeplovoz.AdditionalColor);

            Brush Brush1 = new
            SolidBrush(Color.FromArgb(200, 0, 0, 0));
            g.DrawRectangle(pen, _startPosX, _startPosY,100,25);

            g.DrawLine(pen, _startPosX, _startPosY, _startPosX + 10, _startPosY-15);
            g.DrawLine(pen, _startPosX+10, _startPosY-15, _startPosX + 100, _startPosY - 15);
            g.DrawLine(pen, _startPosX + 100, _startPosY - 15, _startPosX + 100, _startPosY+25);

            Pen pen1 = new(Color.Blue);

            g.DrawRectangle(pen1, _startPosX+13, _startPosY-13, 10, 12);
            g.DrawRectangle(pen1, _startPosX + 26, _startPosY- 13, 10, 12);
            
            g.DrawRectangle(pen, _startPosX + 39, _startPosY - 5, 10, 20);
            g.FillRectangle(Brush1, _startPosX + 39, _startPosY - 5, 10, 20);
            g.DrawRectangle(pen1, _startPosX + 85, _startPosY - 13, 10, 12);

            
            g.DrawLine(pen, _startPosX-10, _startPosY+35, _startPosX, _startPosY + 25);
            g.DrawLine(pen, _startPosX - 10, _startPosY + 35, _startPosX+40, _startPosY + 35);
            g.DrawLine(pen, _startPosX+40, _startPosY + 35, _startPosX + 45, _startPosY + 25);

            g.DrawEllipse(pen, _startPosX, _startPosY + 27, 10, 15);
            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 27, 10, 15);

            g.DrawLine(pen, _startPosX +65, _startPosY + 35, _startPosX+60, _startPosY + 25);
            g.DrawLine(pen, _startPosX +65, _startPosY + 35, _startPosX + 110, _startPosY + 35);
            g.DrawLine(pen, _startPosX + 110, _startPosY + 35, _startPosX + 95, _startPosY + 25);

            g.DrawEllipse(pen, _startPosX + 65, _startPosY + 27, 10, 15);
            g.DrawEllipse(pen, _startPosX + 90, _startPosY + 27, 10, 15);

            g.FillRectangle(Brush1, _startPosX + 100, _startPosY - 13, 5, 38);

            g.FillRectangle(Brush1, _startPosX + 13, _startPosY-30, 7, 15);
            g.FillRectangle(Brush1, _startPosX + 60, _startPosY+10, 30, 15);
        }
    }
}
