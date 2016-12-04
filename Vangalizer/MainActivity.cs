using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.Animations;
using FlatUI;

namespace Vangalizer
{
    [Activity(Label = "Vangalizer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Random r = new Random();

        TextView resultTxt;
        Button myBtn;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Animation animBtn = AnimationUtils.LoadAnimation(ApplicationContext, Resource.Animation.fadeInBtn);
            Animation anim = AnimationUtils.LoadAnimation(ApplicationContext, Resource.Animation.fade_in);

            resultTxt = FindViewById<TextView>(Resource.Id.txtresult);
            myBtn = FindViewById<Button>(Resource.Id.MyButton);

            FlatUI.FlatUI.SetActivityTheme(this, FlatTheme.Grape());

            myBtn.StartAnimation(animBtn);

            string[] resultFraze = Resources.GetStringArray(Resource.Array.yes);

            int max = resultFraze.Length;

                myBtn.Click += delegate {
                        resultTxt.Text = resultFraze[r.Next(0, max)];
                        resultTxt.StartAnimation(anim);
                };
        }
    }
}

