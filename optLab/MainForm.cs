using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

/*
 * TODO:
 * 1. Make only first step try-catch block
 * 2. Get limit one time for fun;
 * 3. Hide form for methods.
 * 4. _x1 and _x2 in Monte-Carlo Method
 * 4.1 List for Monte-Carlo Method (graphic)
 * 4.2 Remake fonts for resultGridView
 * 4.3 All draw logic to new class
*/

namespace optLab
{
    public partial class MainForm : Form
    {
        MSScriptControl.ScriptControl sc;
        double picOffset = 0.125d;
        //ABSOLUTE
        Graphics picGraphics;
        PicPainter picPainter;
        //--------
        Bitmap levels;

        public MainForm()
        {
            InitializeComponent();
            sc = new MSScriptControl.ScriptControl { Language = "VBScript" };
            picGraphics = pictureBox.CreateGraphics();
            pictureBox.Size = new Size(500, 500);
            picPainter = new PicPainter(picGraphics, pictureBox.Width, pictureBox.Height, picOffset);
        }

        private void MakeButton_Click(object sender, EventArgs e)
        {
            var expression = Normalize(funcTextBox.Text);
            switch (methodComboBox.SelectedIndex)
            {
                case 0:
                    BruteMethod(expression);

                    break;
                case 1:
                    MonteCarloMethod(expression);

                    break;
                case 2:
                    HookeJeevesMethod(expression);

                    break;
                case 3:
                    HookeJeevesMethodWithPenalty(expression);

                    break;
                default:
                    MessageBox.Show("Выберите метод.");
                    break;
            }
        }

        private void BruteMethod(string expression)
        {
            var image = new Bitmap(levels);
            var picPainter = new PicPainter(Graphics.FromImage(image), pictureBox.Width, pictureBox.Height, picOffset);
            //picPainter.ClearGraphics();
            var minFx = Double.MaxValue;
            var minX1 = -1d;
            var minX2 = -1d;
            if (!Double.TryParse(addInfoTextBox.Text, out var deltaX)
                || !Double.TryParse(botBorderTextBox.Text, out var botBorder)
                || !Double.TryParse(upBorderTextBox.Text, out var upBorder))
            {
                MessageBox.Show("oops");
                return;
            }
            var size = CalcSize(botBorder, upBorder, deltaX);
            size++;
            object[,] limits;
            try
            {
                limits = CreateLimits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            resultGridView.ColumnCount = size + 1;
            resultGridView.RowCount = size + 1;
            for (var i = 0; i < size + 1; i++)
            {
                resultGridView.Columns[i].Width = 40;
            }
            CreateNumbering(size, deltaX, botBorder);
            var offset = CalcOffset(botBorder, upBorder) + picOffset;
            bool isOk;
            double fx;
            var x1 = botBorder;
            var x2 = botBorder;
            var allFx = new List<double>();
            var allX1 = new List<double>();
            var allX2 = new List<double>();
            var minI = -1;
            var minJ = -1;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    try
                    {
                        isOk = CalcLimits(limits, x1, x2);
                        fx = Math.Round(CalcFunction(expression, x1, x2), 2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " " + ex.StackTrace + " Ошибка при вычислении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (isOk)
                    {
                        picPainter.DrawPoint(x1, x2, botBorder, upBorder, offset);
                        allFx.Add(fx);
                        allX1.Add(x1);
                        allX2.Add(x2);
                        if (minFx > fx)
                        {
                            minFx = fx;
                            minX1 = x1;                            
                            minX2 = x2;                         
                            minI = i;
                            minJ = j;

                        }
                        resultGridView.Rows[size - i - 1].Cells[j + 1].Style.BackColor = Color.White;
                        resultGridView.Rows[size - i - 1].Cells[j + 1].Value = fx;
                    }
                    else
                    {
                        resultGridView.Rows[size - i - 1].Cells[j + 1].Value = fx;
                        resultGridView.Rows[size - i - 1].Cells[j + 1].Style.BackColor = Color.Red;
                    }
                    x2 += deltaX;
                }
                x1 += deltaX;
                x2 = botBorder;
            }
            resultGridView.Rows[size - minI - 1].Cells[minJ + 1].Style.BackColor = Color.Green;
            picPainter.DrawPoint(minX1, minX2, botBorder, upBorder, offset, true);
            fxTextBox.Text = Math.Round(minFx, 2).ToString();
            x1TextBox.Text = Math.Round(minX1, 2).ToString();
            x2TextBox.Text = Math.Round(minX2, 2).ToString();
            for (var i = 0; i < allFx.Count; i++)
                allFx[i] = Math.Round(allFx[i], 2);
            //MakeLines(allFx, allX1, allX2, botBorder, upBorder, offset);
            //picPainter.DrawCoordinateLines(botBorder, upBorder, offset, size, deltaX);          
            pictureBox.Image = image;
        }

        private void MonteCarloMethod(string expression)
        {
            var image = new Bitmap(levels);
            var picPainter = new PicPainter(Graphics.FromImage(image), pictureBox.Width, pictureBox.Height, picOffset);
            //picPainter.ClearGraphics();
            var fxList = new List<double>();
            var fx = Double.MaxValue;
            var x1 = -1d;
            var x2 = -1d;
            var allFx = new List<double>();
            var allX1 = new List<double>();
            var allX2 = new List<double>();
            if (!int.TryParse(addInfoTextBox.Text, out var stepsNum)
                || !Double.TryParse(botBorderTextBox.Text, out var botBorder)
                || !Double.TryParse(upBorderTextBox.Text, out var upBorder))
            {
                MessageBox.Show("oops");
                return;
            }
            var offset = CalcOffset(botBorder, upBorder) + picOffset;
            object[,] limits;
            try
            {
                limits = CreateLimits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            var rnd = new Random();
            var pointCount = 0;
            for (var i = 0; i < stepsNum; i++)
            {
                var _x1 = rnd.NextDouble() * (upBorder - botBorder) + botBorder;
                var _x2 = rnd.NextDouble() * (upBorder - botBorder) + botBorder;
                try
                {
                    var isOk = CalcLimits(limits, _x1, _x2);
                    if (isOk)
                    {
                        var tempFx = CalcFunction(expression, _x1, _x2);
                        picPainter.DrawPoint(_x1, _x2, botBorder, upBorder, offset);
                        allFx.Add(tempFx);
                        allX1.Add(_x1);
                        allX2.Add(_x2);
                        if (tempFx < fx)
                        {
                            fx = tempFx;
                            x1 = _x1;
                            x2 = _x2;
                        }
                        pointCount++;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при вычислении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            picPainter.DrawPoint(x1, x2, botBorder, upBorder, offset, true);
            for (var i = 0; i < allFx.Count; i++)
                allFx[i] = Math.Round(allFx[i], 1);
            fxTextBox.Text = fx.ToString();
            x1TextBox.Text = x1.ToString();
            x2TextBox.Text = x2.ToString();
            addResultTextBox.Text = pointCount.ToString();
            //MakeLines(allFx, allX1, allX2, botBorder, upBorder, offset);
            //picPainter.DrawCoordinateLines(botBorder, upBorder, offset, CalcSize(botBorder, upBorder, 1d) , 0.5d);
            pictureBox.Image = image;

        }

        private void HookeJeevesMethod(string expression)
        {        
            //ADD IMAGE
            var image = new Bitmap(levels);
            var picPainter = new PicPainter(Graphics.FromImage(image), pictureBox.Width, pictureBox.Height, picOffset);
            //picPainter.ClearGraphics();
            var minFx = Double.MaxValue;
            var minX1 = -1d;
            var minX2 = -1d;
            if (!Double.TryParse(addInfoTextBox.Text, out var deltaX)
                || !Double.TryParse(botBorderTextBox.Text, out var botBorder)
                || !Double.TryParse(upBorderTextBox.Text, out var upBorder)
                || !Double.TryParse(hjX1TextBox.Text, out var x1)
                || !Double.TryParse(hjX2TextBox.Text, out var x2))
            {
                MessageBox.Show("oops");
                return;
            }
            var isHorizontal = false;
            var horizontalVector = 0;
            var isVertical = false;
            var verticalVector = 0;
            var size = CalcSize(botBorder, upBorder, deltaX);
            size++;
            var offset = CalcOffset(botBorder, upBorder) + picOffset;
            object[,] limits;
            try
            {
                limits = CreateLimits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            var fx = CalcFunction(expression, x1, x2);
            while (deltaX > 10E-4)
            {
                double newFx = double.MinValue;
                #region Research
                horizontalVector = 0;
                verticalVector = 0;
                //Horizontal
                double minusHorizontalFx = double.MaxValue;
                if(CalcLimits(limits, x1, x2 - deltaX))
                    minusHorizontalFx = CalcFunction(expression, x1, x2 - deltaX);
                double plusHorizontalFx = double.MaxValue;
                if(CalcLimits(limits, x1, x2 + deltaX))
                    plusHorizontalFx = CalcFunction(expression, x1, x2 + deltaX);
                if (minusHorizontalFx < fx || plusHorizontalFx < fx)
                {
                    horizontalVector = minusHorizontalFx <= plusHorizontalFx ? -1 : 1;
                }
                fx = CalcFunction(expression, x1, x2 + deltaX * horizontalVector);
                picPainter.DrawLine(x1, x2, x1, x2 + deltaX * horizontalVector, botBorder, upBorder, offset, Pens.Black);
                x2+= deltaX * horizontalVector;

                //Vertical
                double minusVerticalFx = double.MaxValue;
                if(CalcLimits(limits, x1 - deltaX, x2))
                    minusVerticalFx = CalcFunction(expression, x1 - deltaX, x2);
                double plusVerticalFx = double.MaxValue;
                if (CalcLimits(limits, x1 + deltaX, x2))
                    plusVerticalFx = CalcFunction(expression, x1 + deltaX, x2);
                if (minusVerticalFx < fx || plusVerticalFx < fx)
                {
                    verticalVector = minusVerticalFx <= plusVerticalFx ? -1 : 1;
                }
                fx = CalcFunction(expression, x1 + deltaX * verticalVector, x2);
                picPainter.DrawLine(x1, x2, x1 + deltaX * verticalVector, x2, botBorder, upBorder, offset, Pens.Black);
                x1 += deltaX * verticalVector;
                #endregion
                //
                if (horizontalVector == 0 && verticalVector == 0)
                {
                    deltaX /= 10;
                    continue;
                }
                //fx = newFx;
                #region Pattern maching
                while (true)
                {
                    if (!CalcLimits(limits, x1 + deltaX * verticalVector, x2 + deltaX * horizontalVector)) break;
                    newFx = CalcFunction(expression, x1 + deltaX * verticalVector, x2 + deltaX * horizontalVector);
                    if (newFx < fx)
                    {
                        picPainter.DrawLine(x1, x2, x1 + deltaX * verticalVector, x2 + deltaX * horizontalVector, botBorder, upBorder, offset, Pens.Black);
                        x2 += deltaX * horizontalVector;
                        x1 += deltaX * verticalVector;
                        fx = newFx;
                    }
                    else break;
                }
                #endregion                
            }
            pictureBox.Image = image;
            fxTextBox.Text = fx.ToString();
            x1TextBox.Text = x1.ToString();
            x2TextBox.Text = x2.ToString();

        }

        private void HookeJeevesMethodWithPenalty(string expression)
        {
            //ADD IMAGE
            var image = new Bitmap(levels);
            var picPainter = new PicPainter(Graphics.FromImage(image), pictureBox.Width, pictureBox.Height, picOffset);
            //picPainter.ClearGraphics();
            var minFx = Double.MaxValue;
            var minX1 = -1d;
            var minX2 = -1d;
            if (!Double.TryParse(addInfoTextBox.Text, out var deltaX)
                || !Double.TryParse(botBorderTextBox.Text, out var botBorder)
                || !Double.TryParse(upBorderTextBox.Text, out var upBorder)
                || !Double.TryParse(hjX1TextBox.Text, out var x1)
                || !Double.TryParse(hjX2TextBox.Text, out var x2)
                || !Double.TryParse(rTextBox.Text, out var r))
            {
                MessageBox.Show("oops");
                return;
            }
            var isHorizontal = false;
            var horizontalVector = 0;
            var isVertical = false;
            var verticalVector = 0;
            var size = CalcSize(botBorder, upBorder, deltaX);
            size++;
            var offset = CalcOffset(botBorder, upBorder) + picOffset;
            object[,] limits;
            try
            {
                limits = CreateLimits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            var fx = CalcWithPenalty(x1, x2, r, expression, limits);
            while (deltaX > 10E-4)
            {
                double newFx = double.MinValue;
                #region Research
                horizontalVector = 0;
                verticalVector = 0;
                //Horizontal
                double minusHorizontalFx = CalcWithPenalty(x1, x2 - deltaX, r, expression, limits);
                double plusHorizontalFx = CalcWithPenalty(x1, x2 + deltaX, r, expression, limits);
                if (minusHorizontalFx < fx || plusHorizontalFx < fx)
                {
                    horizontalVector = minusHorizontalFx <= plusHorizontalFx ? -1 : 1;
                }
                fx = CalcWithPenalty(x1, x2 + deltaX * horizontalVector, r, expression, limits);
                picPainter.DrawLine(x1, x2, x1, x2 + deltaX * horizontalVector, botBorder, upBorder, offset, Pens.Black);
                x2 += deltaX * horizontalVector;

                //Vertical
                double minusVerticalFx = CalcWithPenalty(x1 - deltaX, x2, r, expression, limits);
                double plusVerticalFx = CalcWithPenalty(x1 + deltaX, x2, r, expression, limits);
                if (minusVerticalFx < fx || plusVerticalFx < fx)
                {
                    verticalVector = minusVerticalFx <= plusVerticalFx ? -1 : 1;
                }
                fx = CalcFunction(expression, x1 + deltaX * verticalVector, x2);
                picPainter.DrawLine(x1, x2, x1 + deltaX * verticalVector, x2, botBorder, upBorder, offset, Pens.Black);
                x1 += deltaX * verticalVector;
                #endregion
                //
                if (horizontalVector == 0 && verticalVector == 0)
                {
                    deltaX /= 10;
                    continue;
                }
                //fx = newFx;
                #region Pattern maching
                while (true)
                {
                    newFx = CalcWithPenalty(x1 + deltaX * verticalVector, x2 + deltaX * horizontalVector, r, expression, limits);
                    if (newFx < fx)
                    {
                        picPainter.DrawLine(x1, x2, x1 + deltaX * verticalVector, x2 + deltaX * horizontalVector, botBorder, upBorder, offset, Pens.Black);
                        x2 += deltaX * horizontalVector;
                        x1 += deltaX * verticalVector;
                        fx = newFx;
                    }
                    else break;
                }
                #endregion                
            }
            pictureBox.Image = image;
            fxTextBox.Text = fx.ToString();
            x1TextBox.Text = x1.ToString();
            x2TextBox.Text = x2.ToString();

        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodComboBox.SelectedIndex == 0)
            {
                addInfoLabel.Text = "deltaX";
                addInfoLabel.Visible = true;
                addInfoTextBox.Visible = true;
                botBorderLabel.Visible = true;
                botBorderTextBox.Visible = true;
                upBorderLabel.Visible = true;
                upBorderTextBox.Visible = true;
            }
            if (methodComboBox.SelectedIndex == 1)
            {
                addInfoLabel.Text = "Шаги";
                addInfoLabel.Visible = true;
                addInfoTextBox.Visible = true;
                botBorderLabel.Visible = true;
                botBorderTextBox.Visible = true;
                upBorderLabel.Visible = true;
                upBorderTextBox.Visible = true;
            }
            if (methodComboBox.SelectedIndex != 3)
            {
                rLabel.Visible = false;
                rTextBox.Visible = false;
            }
            if (methodComboBox.SelectedIndex == 3)
            {
                rLabel.Visible = true;
                rTextBox.Visible = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (leftTextBox.Text == "" || rightTextBox.Text == "" || signComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Проверьте введеные значения.");
                return;
            }
            limitGridView.Rows.Add(Normalize(leftTextBox.Text), signComboBox.Text, rightTextBox.Text);
            leftTextBox.Text = "";
            rightTextBox.Text = "";
        }

        private object[,] CreateLimits()
        {
            var limits = new object[limitGridView.RowCount, 3];
            for (var i = 0; i < limitGridView.RowCount; i++)
            {
                var left = limitGridView.Rows[i].Cells[0].Value.ToString();
                limits[i, 0] = Normalize(left);
                var sign = limitGridView.Rows[i].Cells[1].Value.ToString();
                limits[i, 1] = sign;
                if (!Double.TryParse(limitGridView.Rows[i].Cells[2].Value.ToString(), out var right))
                {
                    throw new Exception("Ошибка в ограничениях. Строка: " + i);
                }
                limits[i, 2] = right;
            }
            return limits;
        }

        /// <summary>
        /// REMAKE
        /// </summary>
        /// <param name="limits"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        private bool CalcLimits(object[,] limits, double x1, double x2)
        {
            for (var i = 0; i < limits.GetLength(0); i++)
            {
                var exp = limits[i, 0].ToString();
                exp = exp.Replace("x1", x1.ToString());
                exp = exp.Replace("x2", x2.ToString());
                var sign = limits[i, 1].ToString();
                var right = (double)limits[i, 2];
                var limRes = (double)sc.Eval(exp);
                switch (sign)
                {
                    case ">=":
                        if (!((Math.Abs(right - limRes) < 0.001d) || limRes > right))
                            return false;
                        break;
                    case ">":
                        if (!(limRes > right))
                            return false;
                        break;
                    case "<=":
                        if (!((Math.Abs(right - limRes) < 0.001d) || limRes < right))
                            return false;
                        break;
                    case "<":
                        if (!(limRes < right))
                            return false;
                        break;
                }
            }
            return true;
        }

        private double CalcFunction(string expression, double x1, double x2)
        {
            var exp = expression.Replace("x1", x1.ToString());
            exp = exp.Replace("x2", x2.ToString());
            object res = sc.Eval(exp);
            if (!Double.TryParse(res.ToString(), out double fx))
            {
                throw new Exception(x1.ToString() + " " + x2.ToString());
            }
            return fx;
        }

        private double CalcWithPenalty(double x1, double x2, double r, string expression, object[,] limits)
        {

            var sum = 0d;
            for(var i = 0; i < limits.GetLength(0); i++)
            {
                var left = limits[i, 0].ToString();
                var sign = limits[i, 1].ToString();
                var right = (double)limits[i, 2];
                sum += CalcPenalty(x1, x2, left, sign, right);
            }
                
            return CalcFunction(expression, x1, x2) +  r * sum;
        }

        private double CalcPenalty(double x1, double x2, string left, string sign, double right)
        {
            var l = -1d;
            var result = 0d;
            switch (sign)
            {
                case ">":
                    l = CalcFunction(left, x1, x2);
                    result = Math.Abs(l - right);
                    return l > right ? 0 : result;
                case ">=":
                    l = CalcFunction(left, x1, x2);
                    result = Math.Abs(l - right);
                    return l >= right ? 0 : result;
                case "<":
                    l = CalcFunction(left, x1, x2);
                    result = Math.Abs(l - right);
                    return l < right ? 0 : result;
                case "<=":
                    l = CalcFunction(left, x1, x2);
                    result = Math.Abs(l - right);
                    return l <= right ? 0 : result;
                default:
                    return 0;
            }
        }

        private void CreateNumbering(int size, double step, double botBorder)
        {
            resultGridView.Rows[size].Cells[0].Value = "x1/x2";
            var st = botBorder;
            for (int i = 1; i < size + 1; i++)
            {
                resultGridView.Rows[size].Cells[i].Value = Math.Round(st, 2);
                st += step;
            }
            st = botBorder;
            for (int i = 1; i < size + 1; i++)
            {
                resultGridView.Rows[size - i].Cells[0].Value = Math.Round(st, 2);
                st += step;
            }
        }

        private double CalcOffset(double botBorder, double upBorder) => Math.Abs(botBorder) / (Math.Abs(botBorder) + Math.Abs(upBorder));

        private int CalcSize(double botBorder, double upBorder, double deltaX) => (int)((Math.Abs(botBorder) + Math.Abs(upBorder)) / deltaX);

        private void button1_Click(object sender, EventArgs e)
        {
            funcTextBox.Text = "-6*x1+2*x1^2-2*x1*x2+2*x2^2";
            limitGridView.Rows.Add("x1", ">=", 0d);
            limitGridView.Rows.Add("x2", ">=", 0d);
            limitGridView.Rows.Add("x1+x2", "<=", 2d);
            botBorderTextBox.Text = (-1d).ToString();
            upBorderTextBox.Text = (4d).ToString();
        }

        private void limitGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => limitGridView.Rows.RemoveAt(e.RowIndex);

        private string Normalize(string expression)
        {
            for (var i = 0; i < 9; i++)
                expression = expression.Replace(i.ToString() + "x", i.ToString() + "*x");
            expression = expression.Replace("X", "x");
            return expression;
        }

        private void MakeLines(List<double> fx, List<double> x1, List<double> x2, double botBorder, double upBorder, double offset)
        {           
            var res = new Dictionary<double, List<int>>();
            for(var i = 0; i < fx.Count; i++)
            {
                if (!res.Keys.Contains(fx[i]))
                {
                    res.Add(fx[i], new List<int> { i });
                }
                else
                {
                    res[fx[i]].Add(i);
                }
            }


            foreach (var fun in res)
            {
                if (fun.Value.Count > 1)
                {
                    var alreadyDrawn = new List<int>();
                    for (var i = 0; i < fun.Value.Count - 1; i++)
                    {
                        var minLength = double.PositiveInfinity;
                        var index = -1;
                        for (var j = 0; j < fun.Value.Count; j++)
                        {
                            if (i == j) continue;
                            var _i = fun.Value[i];
                            var _j = fun.Value[j];
                            var firstPart = x1[_i] - x1[_j];
                            var secondPart = x2[_i] - x2[_j];
                            var length = Math.Sqrt(firstPart*firstPart + secondPart*secondPart);

                            if (minLength > length & !alreadyDrawn.Contains(j))
                            {
                                index = j;
                                minLength = length;
                            }
                        }
                        if (index == -1) break;
                        var iCoord = fun.Value[i];
                        var jCoord = fun.Value[index];
                        picPainter.DrawLine(x1[iCoord], x2[iCoord], x1[jCoord], x2[jCoord], botBorder, upBorder, offset, Pens.Red);
                         
                        alreadyDrawn.Add(index);

                    }
                }
            }
            //foreach (var fun in res)
            //{
            //    if (fun.Value.Count > 1)
            //    {
            //        for (var i = 0; i < fun.Value.Count - 1; i++)
            //        {
            //            for (var j = i + 1; j < fun.Value.Count; j++)
            //            {
            //                var _i = fun.Value[i];
            //                var _j = fun.Value[j];
            //                picPainter.DrawLine(x1[_i], x2[_i], x1[_j], x2[_j], botBorder, upBorder, offset);
            //            }
            //        }
            //    }
            //}
        }

        private Bitmap MakeLevels(List<double> fx, List<double> x1, List<double> x2, double botBorder, double upBorder, double offset, int width, int height, int size, double deltaX)
        {
            var bitmap = new Bitmap(width, height);
            var graphics = Graphics.FromImage(bitmap);
            
            var painter = new PicPainter(graphics, width, height, picOffset);
            painter.ClearGraphics();

            //First step
            painter.DrawCoordinateLines(botBorder, upBorder, offset, size, 0.5d);

            var list = new List<double>();
            //Second step
            var res = new Dictionary<double, List<int>>();
            for (var i = 0; i < fx.Count; i++)
            {
                if (!res.Keys.Contains(fx[i]))
                {
                    res.Add(fx[i], new List<int> { i });
                }
                else
                {
                    res[fx[i]].Add(i);
                }
            }           
            

            foreach (var fun in res)
            {
                if (fun.Value.Count > 1)
                {
                    var alreadyDrawn = new List<int>();
                    for (var i = 0; i < fun.Value.Count - 1; i++)
                    {
                        var minLength = double.PositiveInfinity;
                        var index = -1;
                        for (var j = 0; j < fun.Value.Count; j++)
                        {
                            if (i == j) continue;
                            var _i = fun.Value[i];
                            var _j = fun.Value[j];
                            var firstPart = x1[_i] - x1[_j];
                            var secondPart = x2[_i] - x2[_j];
                            var length = Math.Sqrt(firstPart * firstPart + secondPart * secondPart);

                            if (minLength > length & !alreadyDrawn.Contains(j))
                            {
                                index = j;
                                minLength = length;
                            }
                        }
                        if (index == -1) break;
                        var iCoord = fun.Value[i];
                        var jCoord = fun.Value[index];
                        painter.DrawLine(x1[iCoord], x2[iCoord], x1[jCoord], x2[jCoord], botBorder, upBorder, offset, Pens.Red);

                        alreadyDrawn.Add(index);

                    }
                }
            }

            return bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var expression = funcTextBox.Text;
            if (!Double.TryParse(botBorderTextBox.Text, out var botBorder)
             || !Double.TryParse(upBorderTextBox.Text, out var upBorder))
            {
                MessageBox.Show("oops");
                return;
            }
            var deltaX = 0.1d;
            var size = CalcSize(botBorder, upBorder, deltaX);
            size++;
            object[,] limits;
            try
            {
                limits = CreateLimits();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            var offset = CalcOffset(botBorder, upBorder) + picOffset;
            bool isOk;
            double fx;
            var x1 = botBorder;
            var x2 = botBorder;
            var allFx = new List<double>();
            var allX1 = new List<double>();
            var allX2 = new List<double>();
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    try
                    {
                        isOk = CalcLimits(limits, x1, x2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " " + ex.StackTrace + " Ошибка при вычислении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (isOk)
                    {
                        try
                        {
                            fx = CalcFunction(expression, x1, x2);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " " + ex.StackTrace + " Ошибка при вычислении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        allFx.Add(fx);
                        allX1.Add(x1);
                        allX2.Add(x2);
                    }
                    x2 += deltaX;
                }
                x1 += deltaX;
                x2 = botBorder;
            }
            for (var i = 0; i < allFx.Count; i++)
                allFx[i] = Math.Round(allFx[i], 2);
            var image = MakeLevels(allFx, allX1, allX2, botBorder, upBorder, offset, pictureBox.Width, pictureBox.Height, size, deltaX);
            pictureBox.Image = image;
            levels = image;
        }
    }
}
