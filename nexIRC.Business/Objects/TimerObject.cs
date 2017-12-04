 using System.Threading;
namespace nexIRC.Business.Objects {
    /// <summary>
    /// Timer Object
    /// </summary>
    public class TimerObject {
        /// <summary>
        /// Seconds
        /// </summary>
        private int _seconds;
        /// <summary>
        /// Timer
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// On Tick
        /// </summary>
        public event Tick onTick;
        /// <summary>
        /// Tick
        /// </summary>
        public delegate void Tick();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="seconds"></param>
        public TimerObject(int seconds) {
            _seconds = seconds;
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start() {
            _timer = new Timer(_ => OnCallBack(), null, 10, Timeout.Infinite);
        }
        /// <summary>
        /// On Call Back
        /// </summary>
        private void OnCallBack() {
            if (onTick != null) {
                onTick();
            }
        }
        /// <summary>
        /// Stop
        /// </summary>
        public void Stop() {
            _timer.Dispose();
            _timer = new Timer(_ => OnCallBack(), null, 1000 * 10, Timeout.Infinite);
        }
    }
}