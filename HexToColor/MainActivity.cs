using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace HexToColor
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // Aaron Sanders: Creating view controls
        TextView redText, greenText, blueText;
        EditText editHex;
        Button convertButton;
        LinearLayout colorFrameLinLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Aaron Sanders: Instantiating view controls
            convertButton = FindViewById<Button>(HexToColor.Resource.Id.convertButton);
            editHex = FindViewById<EditText>(HexToColor.Resource.Id.editHex);
            redText = FindViewById<TextView>(HexToColor.Resource.Id.redText);
            greenText = FindViewById<TextView>(HexToColor.Resource.Id.greenText);
            blueText = FindViewById<TextView>(HexToColor.Resource.Id.blueText);
            colorFrameLinLayout = FindViewById<LinearLayout>(HexToColor.Resource.Id.colorFrameLinLayout);

            convertButton.Click += convertButton_Click;

            // var colorChanger = editHex.Text;                                 
        }

        
        private void convertButton_Click(object sender, EventArgs e)
        {
            string hexvalue = editHex.Text;
            string redTextv = hexvalue.Substring(0, 2);
            string greenTextv = hexvalue.Substring(2, 2);
            string blueTextv = hexvalue.Substring(4, 2);            

            int redvalue = int.Parse(redTextv, System.Globalization.NumberStyles.HexNumber);
            int greenvalue = int.Parse(greenTextv, System.Globalization.NumberStyles.HexNumber);
            int bluevalue = int.Parse(blueTextv, System.Globalization.NumberStyles.HexNumber);

            //Set color text views string values equal to the substring color hex values
            redText.Text = redvalue.ToString();
            blueText.Text = bluevalue.ToString();
            greenText.Text = greenvalue.ToString();

            colorFrameLinLayout.SetBackgroundColor(Android.Graphics.Color.Argb(255, redvalue, greenvalue, bluevalue));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

