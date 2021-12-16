using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Russian_Pereprava
{
    class Game
    {
        public Game()
        {
            for (int i = (int)Positions.Left_1; i <= (int)Positions.Left_8; i++)
            {
                zanyato[i] = true;
                cheloveki[i].Posit = (Positions)i;
            }
        }

        string Bobik_side = "LEFT";
        bool[] zanyato = new bool[20];
        readonly List<Point> positions = new List<Point>()
        {
            new Point(34, 483),new Point(180,483),new Point(491,483),new Point(387,565),new Point(635,565),
            new Point(850,483),new Point(755,565),new Point(1004,565),new Point(338,681),new Point(488,681),
            new Point(707,797),new Point(855,797),new Point(1446,747),new Point(1277,849),new Point(1178,906),
            new Point(1408,906),new Point(1612,747),new Point(1637,860),new Point(1553,920),new Point(1768,920)
        };
        //Енам для удобства индексации, список для записи возможных позиций, если бы можно в енаме указать значением поинт, то сделал бы так 
        List<Chel> cheloveki = new List<Chel>()
        {
            new Chel(new Point(34, 483),125,107,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\Cop.jpg","Cop"),
            new Chel(new Point(180,483),125,107,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\Alkash.jpg","Alkash"),
            new Chel(new Point(850,483),125,107,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\Batya.jpg","Batya"),
            new Chel(new Point(491,483),125,107,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\Maman.jpg","Maman"),
            new Chel(new Point(387,565),78,84,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\doch.jpg","Dotch"),
            new Chel(new Point(635,565),78,84,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\doch.jpg","Dotch"),
            new Chel(new Point(755,565),78,84,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\Sin.png","Sin"),
            new Chel(new Point(1004,565),78,84,@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\Sin.png","Sin")
        };
        public void Update(int M_X, int M_Y)
        {
            if (M_X == 9999 && M_Y == 9999)//кнопка плыть
            {
                bool error = false;
                if (Bobik_side == "LEFT")
                {
                    if (!zanyato[(int)Positions.Left_boat_1] && !zanyato[(int)Positions.Left_boat_2]) error = true;
                    else
                    {

                        foreach (Chel chel in cheloveki)
                        {
                            if (chel.Posit == Positions.Left_boat_1 || chel.Posit == Positions.Left_boat_2)
                            {
                                if (chel.Name == "Cop")//Единственная ошибка - когда коп уезжает без вора и на первом берегу остаются челы
                                {
                                    bool alkash = false;
                                    bool others = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit <= Positions.Left_8)
                                        {
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash = true;
                                            }
                                            if (chel1.Name == "Batya" || chel1.Name == "Maman" || chel1.Name == "Dotch" || chel1.Name == "Sin")
                                            {
                                                others = true;
                                            }
                                        }
                                    }
                                    if (alkash && others)
                                    {
                                        error = true;
                                        break;
                                    }

                                }
                                if (chel.Name == "Alkash")//Если вор уезжает, коп слева и справа есть остальные
                                {
                                    bool cop = false;
                                    bool others1 = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit <= Positions.Left_8)
                                        {
                                            if (chel1.Name == "Cop")
                                            {
                                                cop = true;
                                            }
                                        }
                                        if (chel1.Posit >= Positions.Right_1)
                                        {
                                            if (chel1.Name == "Batya" || chel1.Name == "Maman" || chel1.Name == "Dotch" || chel1.Name == "Sin")
                                            {
                                                others1 = true;
                                            }
                                        }
                                    }
                                    if (cop && others1)
                                    {
                                        error = true;
                                        break;
                                    }
                                }

                                if (chel.Name == "Maman")//если уезжает маман и на берегу остаются дочь и отец||уезжает и на том берегу есть сын и нет отца||едет и там есть вор, но нет копа
                                {//едет с вором и там нет копа||едет с сыном и там нет отца
                                    bool daughter_left = false;
                                    bool father_left = false;
                                    bool son_right_boat = false;
                                    bool cop_left = false;
                                    bool alkash_right_boat = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit <= Positions.Left_8)
                                        {
                                            if (chel1.Name == "Dotch")
                                            {
                                                daughter_left = true;
                                            }
                                            if (chel1.Name == "Batya")
                                            {
                                                father_left = true;
                                            }
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_left = true;
                                            }
                                        }
                                        if (chel1.Posit >= Positions.Left_boat_1)
                                        {
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_right_boat = true;
                                            }
                                            if (chel1.Name == "Sin")
                                            {
                                                son_right_boat = true;
                                            }
                                        }
                                    }
                                    if ((daughter_left && father_left) || (father_left && son_right_boat) || (cop_left && alkash_right_boat))
                                    {
                                        error = true;
                                        break;
                                    }
                                }

                                if (chel.Name == "Batya")//если уезжает батя и на берегу остаются мама и сын||уезжает и на том берегу есть дочь и нет матери||едет и там есть вор, но нет копа
                                {//едет с вором и там нет копа||едет с дочерью и там нет матери
                                    bool son_left = false;
                                    bool mother_left = false;
                                    bool dotch_right_boat = false;
                                    bool cop_left = false;
                                    bool alkash_right_boat = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit <= Positions.Left_8)
                                        {

                                            if (chel1.Name == "Sin")
                                            {
                                                son_left = true;
                                            }
                                            if (chel1.Name == "Maman")
                                            {
                                                mother_left = true;
                                            }
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_left = true;
                                            }
                                        }
                                        if (chel1.Posit >= Positions.Left_boat_1)
                                        {
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_right_boat = true;
                                            }
                                            if (chel1.Name == "Dotch")
                                            {
                                                dotch_right_boat = true;
                                            }
                                        }

                                    }
                                    if ((son_left && mother_left) || (mother_left && dotch_right_boat) || (cop_left && alkash_right_boat))
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                                if (chel.Name == "Sin")
                                {
                                    bool cop_left = false;
                                    bool alkash_right_boat = false;
                                    bool maman_right_boat = false;
                                    bool father_left = false;
                                    bool other_child_or_empty = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit <= Positions.Left_8)
                                        {
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_left = true;
                                            }
                                            if (chel1.Name == "Batya")
                                            {
                                                father_left = true;
                                            }
                                        }
                                        if (chel1.Posit >= Positions.Left_boat_1)
                                        {
                                            if (chel1.Name == "Maman")
                                            {
                                                maman_right_boat = true;
                                            }
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_right_boat = true;
                                            }
                                        }
                                        if (chel.Posit == Positions.Left_boat_1 && chel1.Posit == Positions.Left_boat_2 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Left_boat_1 && !zanyato[(int)Positions.Left_boat_2])
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Left_boat_2 && chel1.Posit == Positions.Left_boat_1 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Left_boat_2 && !zanyato[(int)Positions.Left_boat_1])
                                        {
                                            other_child_or_empty = true;
                                        }
                                    }
                                    if ((cop_left && alkash_right_boat) || (father_left && maman_right_boat) || other_child_or_empty)
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                                if (chel.Name == "Dotch")
                                {
                                    bool cop_left = false;
                                    bool alkash_right_boat = false;
                                    bool father_right_boat = false;
                                    bool maman_left = false;
                                    bool other_child_or_empty = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit <= Positions.Left_8)
                                        {
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_left = true;
                                            }
                                            if (chel1.Name == "Maman")
                                            {
                                                maman_left = true;
                                            }
                                        }
                                        if (chel1.Posit >= Positions.Left_boat_1)
                                        {
                                            if (chel1.Name == "Batya")
                                            {
                                                father_right_boat = true;
                                            }
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_right_boat = true;
                                            }
                                        }
                                        if (chel.Posit == Positions.Left_boat_1 && chel1.Posit == Positions.Left_boat_2 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Left_boat_1 && !zanyato[(int)Positions.Left_boat_2])
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Left_boat_2 && chel1.Posit == Positions.Left_boat_1 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Left_boat_2 && !zanyato[(int)Positions.Left_boat_1])
                                        {
                                            other_child_or_empty = true;
                                        }
                                    }
                                    if ((cop_left && alkash_right_boat) || (maman_left && father_right_boat) || other_child_or_empty)
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                            }
                            //СЫН
                            //Если второй чел дочь или сын или пустой
                            //Если едет с алкашом и коп остаётся слева или алкаш уже справа и коп остаётся слева
                            //Если мама справа или в лодке и батя остаётся слева
                            //Если


                        }

                    }
                    if (!error)//собсна лодка плывёт
                    {
                        Bobik_side = "RIGHT";

                        foreach (Chel chel in cheloveki)
                        {
                            if (chel.Posit == Positions.Left_boat_1)
                            {
                                chel.Posit = Positions.Right_boat_1;
                                chel.Change_cords(positions[(int)Positions.Right_boat_1]);
                                zanyato[(int)Positions.Right_boat_1] = true;
                                zanyato[(int)Positions.Left_boat_1] = false;
                            }
                            else if (chel.Posit == Positions.Left_boat_2)
                            {
                                chel.Posit = Positions.Right_boat_2;
                                chel.Change_cords(positions[(int)Positions.Right_boat_2]);
                                zanyato[(int)Positions.Right_boat_2] = true;
                                zanyato[(int)Positions.Left_boat_2] = false;
                            }
                        }
                    }


                }
                else
                {
                    if (!zanyato[(int)Positions.Right_boat_1] && !zanyato[(int)Positions.Right_boat_2]) error = true;
                    else
                    {
                        foreach (Chel chel in cheloveki)
                        {
                            if (chel.Posit == Positions.Right_boat_1 || chel.Posit == Positions.Right_boat_2)
                            {
                                if (chel.Name == "Cop")//Единственная ошибка - когда коп уезжает без вора и на первом берегу остаются челы
                                {
                                    bool alkash = false;
                                    bool others = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit >= Positions.Right_1)
                                        {
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash = true;
                                            }
                                            if (chel1.Name == "Batya" || chel1.Name == "Maman" || chel1.Name == "Dotch" || chel1.Name == "Sin")
                                            {
                                                others = true;
                                            }
                                        }
                                    }
                                    if (alkash && others)
                                    {
                                        error = true;
                                        break;
                                    }

                                }
                                if (chel.Name == "Alkash")//Если вор уезжает, коп слева и справа есть остальные
                                {
                                    bool cop = false;
                                    bool others1 = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit >= Positions.Right_1)
                                        {
                                            if (chel1.Name == "Cop")
                                            {
                                                cop = true;
                                            }
                                        }
                                        if (chel1.Posit <= Positions.Left_8)
                                        {
                                            if (chel1.Name == "Batya" || chel1.Name == "Maman" || chel1.Name == "Dotch" || chel1.Name == "Sin")
                                            {
                                                others1 = true;
                                            }
                                        }
                                    }
                                    if (cop && others1)
                                    {
                                        error = true;
                                        break;
                                    }
                                }

                                if (chel.Name == "Maman")//если уезжает маман и на берегу остаются дочь и отец||уезжает и на том берегу есть сын и нет отца||едет и там есть вор, но нет копа
                                {//едет с вором и там нет копа||едет с сыном и там нет отца
                                    bool daughter_right = false;
                                    bool father_right = false;
                                    bool son_left_boat = false;
                                    bool cop_right = false;
                                    bool alkash_left_boat = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit >= Positions.Right_1)
                                        {
                                            if (chel1.Name == "Dotch")
                                            {
                                                daughter_right = true;
                                            }
                                            if (chel1.Name == "Batya")
                                            {
                                                father_right = true;
                                            }
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_right = true;
                                            }
                                        }
                                        if (chel1.Posit <= Positions.Right_boat_2)
                                        {
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_left_boat = true;
                                            }
                                            if (chel1.Name == "Sin")
                                            {
                                                son_left_boat = true;
                                            }
                                        }
                                    }
                                    if ((daughter_right && father_right) || (father_right && son_left_boat) || (cop_right && alkash_left_boat))
                                    {
                                        error = true;
                                        break;
                                    }
                                }

                                if (chel.Name == "Batya")//если уезжает батя и на берегу остаются мама и сын||уезжает и на том берегу есть дочь и нет матери||едет и там есть вор, но нет копа
                                {//едет с вором и там нет копа||едет с дочерью и там нет матери
                                    bool son_right = false;
                                    bool mother_right = false;
                                    bool dotch_left_boat = false;
                                    bool cop_right = false;
                                    bool alkash_left_boat = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit >= Positions.Right_1)
                                        {

                                            if (chel1.Name == "Sin")
                                            {
                                                son_right = true;
                                            }
                                            if (chel1.Name == "Maman")
                                            {
                                                mother_right = true;
                                            }
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_right = true;
                                            }
                                        }
                                        if (chel1.Posit <= Positions.Right_boat_2)
                                        {
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_left_boat = true;
                                            }
                                            if (chel1.Name == "Dotch")
                                            {
                                                dotch_left_boat = true;
                                            }
                                        }

                                    }
                                    if ((son_right && mother_right) || (mother_right && dotch_left_boat) || (cop_right && alkash_left_boat))
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                                if (chel.Name == "Sin")
                                {
                                    bool cop_right = false;
                                    bool alkash_left_boat = false;
                                    bool maman_left_boat = false;
                                    bool father_right = false;
                                    bool other_child_or_empty = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit >= Positions.Right_1)
                                        {
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_right = true;
                                            }
                                            if (chel1.Name == "Batya")
                                            {
                                                father_right = true;
                                            }
                                        }
                                        if (chel1.Posit <= Positions.Right_boat_2)
                                        {
                                            if (chel1.Name == "Maman")
                                            {
                                                maman_left_boat = true;
                                            }
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_left_boat = true;
                                            }
                                        }
                                        if (chel.Posit == Positions.Right_boat_1 && chel1.Posit == Positions.Right_boat_2 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Right_boat_1 && !zanyato[(int)Positions.Right_boat_2])
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Right_boat_2 && chel1.Posit == Positions.Right_boat_1 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Right_boat_2 && !zanyato[(int)Positions.Right_boat_1])
                                        {
                                            other_child_or_empty = true;
                                        }
                                    }
                                    if ((cop_right && alkash_left_boat) || (father_right && maman_left_boat) || other_child_or_empty)
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                                if (chel.Name == "Dotch")
                                {
                                    bool cop_right = false;
                                    bool alkash_left_boat = false;
                                    bool father_left_boat = false;
                                    bool maman_right = false;
                                    bool other_child_or_empty = false;
                                    foreach (Chel chel1 in cheloveki)
                                    {
                                        if (chel1.Posit >= Positions.Right_1)
                                        {
                                            if (chel1.Name == "Cop")
                                            {
                                                cop_right = true;
                                            }
                                            if (chel1.Name == "Maman")
                                            {
                                                maman_right = true;
                                            }
                                        }
                                        if (chel1.Posit <= Positions.Right_boat_2)
                                        {
                                            if (chel1.Name == "Batya")
                                            {
                                                father_left_boat = true;
                                            }
                                            if (chel1.Name == "Alkash")
                                            {
                                                alkash_left_boat = true;
                                            }
                                        }
                                        if (chel.Posit == Positions.Right_boat_1 && chel1.Posit == Positions.Right_boat_2 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Right_boat_1 && !zanyato[(int)Positions.Right_boat_2])
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Right_boat_2 && chel1.Posit == Positions.Right_boat_1 && (chel1.Name == "Sin" || chel1.Name == "Dotch"))
                                        {
                                            other_child_or_empty = true;
                                        }
                                        if (chel.Posit == Positions.Right_boat_2 && !zanyato[(int)Positions.Right_boat_1])
                                        {
                                            other_child_or_empty = true;
                                        }
                                    }
                                    if ((cop_right && alkash_left_boat) || (maman_right && father_left_boat) || other_child_or_empty)
                                    {
                                        error = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!error)//собсна лодка плывёт
                        {
                            Bobik_side = "LEFT";

                            foreach (Chel chel in cheloveki)
                            {
                                if (chel.Posit == Positions.Right_boat_1)
                                {
                                    chel.Posit = Positions.Left_boat_1;
                                    chel.Change_cords(positions[(int)Positions.Left_boat_1]);
                                    zanyato[(int)Positions.Left_boat_1] = true;
                                    zanyato[(int)Positions.Right_boat_1] = false;
                                }
                                else if (chel.Posit == Positions.Right_boat_2)
                                {
                                    chel.Posit = Positions.Left_boat_2;
                                    chel.Change_cords(positions[(int)Positions.Left_boat_2]);
                                    zanyato[(int)Positions.Left_boat_2] = true;
                                    zanyato[(int)Positions.Right_boat_2] = false;
                                }
                            }
                        }
                    }


                }
            }
            else
            {
                foreach (Chel chel in cheloveki)
                {
                    if (M_X >= chel.X && M_X <= chel.X + chel.Width && M_Y >= chel.Y && M_Y <= chel.Y + chel.Height)
                    {
                        if (Bobik_side == "LEFT" && chel.Posit >= Positions.Left_1 && chel.Posit <= Positions.Left_8) //левый берег
                        {
                            for (int i = (int)Positions.Left_boat_1; i <= (int)Positions.Left_boat_2; i++)//позиции лодки, хз почему надо преобразовывать, если енам по дефолту интовый
                            {
                                if (!zanyato[i])
                                {
                                    chel.Change_cords(positions[i]);
                                    zanyato[i] = true;
                                    zanyato[(int)chel.Posit] = false;
                                    chel.Posit = (Positions)i;
                                    break;
                                }
                            }
                        }
                        else if (Bobik_side == "LEFT" && chel.Posit >= Positions.Left_boat_1 && chel.Posit <= Positions.Left_boat_2)
                        {
                            for (int i = (int)Positions.Left_1; i <= (int)Positions.Left_8; i++)
                            {
                                if (!zanyato[i])
                                {
                                    chel.Change_cords(positions[i]);
                                    zanyato[i] = true;
                                    zanyato[(int)chel.Posit] = false;
                                    chel.Posit = (Positions)i;
                                    break;
                                }
                            }
                        }
                        else if (Bobik_side == "RIGHT" && chel.Posit >= Positions.Right_boat_1 && chel.Posit <= Positions.Right_boat_2)
                        {
                            for (int i = (int)Positions.Right_1; i <= (int)Positions.Right_8; i++)
                            {
                                if (!zanyato[i])
                                {
                                    chel.Change_cords(positions[i]);
                                    zanyato[i] = true;
                                    zanyato[(int)chel.Posit] = false;
                                    chel.Posit = (Positions)i;
                                    break;
                                }
                            }
                        }
                        else if (Bobik_side == "RIGHT" && chel.Posit >= Positions.Right_1 && chel.Posit <= Positions.Right_8)
                        {
                            for (int i = (int)Positions.Right_boat_1; i <= (int)Positions.Right_boat_2; i++)
                            {
                                if (!zanyato[i])
                                {
                                    chel.Change_cords(positions[i]);
                                    zanyato[i] = true;
                                    zanyato[(int)chel.Posit] = false;
                                    chel.Posit = (Positions)i;
                                    break;
                                }
                            }
                        }
                        //в первом и последнем можно сделать на одно условие меньше, но оставлю опять же для удобства индексации
                    }
                }
            }


        }
        public bool CheckWin()
        {
            bool Win = true;
            for (int i = 12; i < 20; i++)
            {
                if (!zanyato[i])
                {
                    Win = false;
                }
            }
            return Win;

        }
        public void Draw(Graphics gr)
        {
            if (Bobik_side == "LEFT") gr.DrawImage(Image.FromFile(@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\lodka.png"), 314, 704);
            else gr.DrawImage(Image.FromFile(@"C:\Users\ivanb\OneDrive\Рабочий стол\ООП\Anime_res\lodka.png"), 673, 831);
            foreach (Chel item in cheloveki)
            {
                item.Draw(gr);
            }
            
        }
    }
}
