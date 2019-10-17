using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace TicTacToe
{
    
    public class BoardPosition
    {
        

        public int BoardIndexTop { get; set; }
        public int GridRowTop { get; set; }
        public int GridColumnTop { get; set; }

        public int BoardIndexBottom { get; set; }
        public int GridRowBottom { get; set; }
        public int GridColumnBottom { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        private List<BoardPosition> _snakes;
        private List<BoardPosition> _ladders;

        private const int _rows = 5, _cols = 5;
        public MainPage()
        {
            InitializeComponent();
            SetupBoard();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LabelDetails.Text = "GameBoard X " + GameBoard.Width + ", Y " + GameBoard.Height;
            ImagePlayer1.SetValue(Grid.ColumnProperty, 3);

        }
        private void BtnMovePlayer_Clicked(object sender, EventArgs e)
        {
            int i, spaces = 3;
            spaces = Math.Abs(Convert.ToInt32(EntryNumber.Text));

            //await DisplayAlert("Board Details", "GameBoard X " + GameBoard.Width + ", Y " + GameBoard.Height, "cancel");
            

            int step = spaces / Convert.ToInt32(EntryNumber.Text);

            for ( i = 0; i < spaces; i++)
            {
                
                ImagePlayer1.SetValue(Grid.ColumnProperty,
                    (int)ImagePlayer1.GetValue(Grid.ColumnProperty) + step);
            }
            LabelDetails.Text = "Image on row " + (int)ImagePlayer1.GetValue(Grid.RowProperty) +
                    " column " + (int)ImagePlayer1.GetValue(Grid.ColumnProperty);
        }

        private async void BtnTranslateToPlayer_Clicked(object sender, EventArgs e)
        {
            double x, y;
            int spaces = Convert.ToInt32(EntryNumber.Text);
            double currentX, currentY;

            //await DisplayAlert("Board Details", "GameBoard X " + GameBoard.Width + ", Y " + GameBoard.Height, "cancel");

            currentX = ImagePlayer1.X;
            currentY = ImagePlayer1.Y;


            double step = (GameBoard.Width / 10) * spaces;

            x = step;
            y = currentY;

            await ImagePlayer1.TranslateTo(x, 0, 500);

            ImagePlayer1.SetValue(Grid.ColumnProperty,
                    (int)ImagePlayer1.GetValue(Grid.ColumnProperty) + spaces);
            LabelDetails.Text = "Image on row " + (int)ImagePlayer1.GetValue(Grid.RowProperty) +
                                " column " + (int)ImagePlayer1.GetValue(Grid.ColumnProperty) +
                                " X= " + ImagePlayer1.X;
        }

        private void SetupBoard()
        {
            _snakes = new List<BoardPosition>();
            _ladders = new List<BoardPosition>();
            Image image;
            BoardPosition ladder;
            BoardPosition snake;

            snake = new BoardPosition
            {
                BoardIndexTop = 19,
                GridRowTop = 1,
                GridColumnTop = 1,
                BoardIndexBottom = 8,
                GridRowBottom = 3,
                GridColumnBottom = 2
            };
            _snakes.Add(snake);

            image = new Image();
            var assembly = typeof(MainPage);
            string strFilename = "TicTacToe.snake1.png";

            image.Source = ImageSource.FromResource(
                strFilename, assembly);

            image.SetValue(Grid.RowProperty, 1);
            image.SetValue(Grid.ColumnProperty, 1);
            image.SetValue(Grid.RowSpanProperty, 3);
            image.SetValue(Grid.ColumnSpanProperty, 2);

            ladder = new BoardPosition
            {
                BoardIndexTop = 14,
                GridRowTop = 2,
                GridColumnTop = 3,
                BoardIndexBottom = 6,
                GridRowBottom = 3,
                GridColumnBottom = 4
            };

            image = new Image();
            assembly = typeof(MainPage);
            strFilename = "TicTacToe.ladder1.png";

            image.Source = ImageSource.FromResource(strFilename, assembly);

            image.SetValue(Grid.RowProperty, 2);
            image.SetValue(Grid.ColumnProperty, 3);
            image.SetValue(Grid.RowSpanProperty, 2);
            image.SetValue(Grid.ColumnSpanProperty, 2);
//            GameBoardGrid.Children.Add(image);



        }
    }
}
