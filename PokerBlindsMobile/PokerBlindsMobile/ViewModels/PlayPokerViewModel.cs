using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokerBlindsMobile.ViewModels
{
    public class PlayPokerViewModel : BaseViewModel
    {
        private TimeSpan _currentTime;
        public TimeSpan CurrentTime 
        { 
            get { return _currentTime; }
            set 
            {
                if (TimeSpan.Compare(value, TimeSpan.Zero) < 0)
                {
                    SetValue(ref _currentTime, new TimeSpan(0, 1, 0));
                }
                else
                {
                    SetValue(ref _currentTime, value);
                }
            }
        }

        private bool _timerToggle;
        public bool TimerToggle { 
            get { return _timerToggle; } 
            set { SetValue(ref _timerToggle, value); }
        }

        public PlayPokerViewModel()
        {
            CurrentTime = new TimeSpan(0, 0, 10);
            TimerToggle = false;
        }

        public ICommand StartStopTimerCommand { get { return new Command<bool>((param) => StartStopTimer(param)); } }
        private void StartStopTimer(bool shouldStart)
        {
            if (shouldStart)
            {
                TimerToggle = shouldStart;

                var second = TimeSpan.FromSeconds(1);
                Device.StartTimer(second, () => {
                    CurrentTime = CurrentTime.Subtract(second);
                    return TimerToggle;
                });
            }
            else
            {
                TimerToggle = shouldStart;
            }

            Debug.WriteLine($"Toggle is: {shouldStart}");
        }
    }
}
