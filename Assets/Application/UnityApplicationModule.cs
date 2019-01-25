using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UnityApplicationModule", menuName = "Installers/UnityApplicationModule")]
public class UnityApplicationModule : ScriptableObjectInstaller<UnityApplicationModule>
{
    public override void InstallBindings()
    {
        ApplicationModule.Install(Container);
    }
}