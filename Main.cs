using Blueprints.GUI;
using Blueprints.Tools;
using Timber_and_Stone.API;
using Timber_and_Stone.TNS_GUI;

namespace Blueprints
{
    public class Main : IPlugin
    {
        public void OnLoad()
        {
            GUIRegistry.RegisterGUI<GUIMain>();

            var c = GUIManager.getInstance().controllerObj.GetComponent<ControlPlayer>()
                .FullCamera.gameObject.AddComponent<Box>();
        }

        public void OnEnable() {  }

        public void OnDisable() {  }
    }
}
