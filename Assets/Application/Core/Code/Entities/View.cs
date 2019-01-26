using DG.Tweening;
using GGJ2019.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityCore.Entities
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class View : MonoBehaviour, IWindow
    {
        public CanvasGroup CanvasGroup { get; private set; }

        protected virtual void Awake()
        {
            CanvasGroup = this.GetComponent<CanvasGroup>();
        }

        protected virtual void Start()
        {
            CanvasGroup.alpha = 0f;
        }

        protected virtual void OnDestroy() { }

        public virtual async Task Hide(CancellationToken cancellationToken)
        {
            await CanvasGroup.DOFade(0f, 0.5f).DOAsync(cancellationToken);
            this.gameObject.SetActive(false);
        }

        public virtual Task Show(CancellationToken cancellationToken)
        {
            this.gameObject.SetActive(true);
            return CanvasGroup.DOFade(1f, 0.5f).DOAsync(cancellationToken);
        }

        public void Initialize(IRoot root)
        {
            if (root != null)
            {
                transform.SetParent((root as Root).UiRoot.transform, false);
                transform.SetAsLastSibling();
            }
            else
            {
                transform.SetParent(null);
            }
        }
    }
}
