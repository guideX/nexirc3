using nexIRC.Models.Global;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Status Controller
    /// </summary>
    public class StatusBusiness {
        #region "private variables"
        /// <summary>
        /// Global Object Model
        /// </summary>
        private GlobalObjectModel _globalObject;
        #endregion
        #region "methods"
        /// <summary>
        /// Status Controller
        /// </summary>
        public StatusBusiness(GlobalObjectModel globalObject) {
            _globalObject = globalObject;
        }
        #endregion
    }
}