using UnityEngine;

namespace DuloGames.UI
{
    [ExecuteInEditMode, AddComponentMenu("UI/Color Scheme Element", 48)]
    public class ColorSchemeElement : MonoBehaviour
    {
        [SerializeField] private ColorSchemeElementType m_ElementType = ColorSchemeElementType.Image;

        public ColorSchemeElementType elementType
        {
            get { return this.m_ElementType; }
            set { this.m_ElementType = value; }
        }

        [SerializeField] private ColorSchemeShade m_Shade = ColorSchemeShade.Light;

        public ColorSchemeShade shade
        {
            get { return this.m_Shade; }
            set { this.m_Shade = value; }
        }

        protected void Awake()
        {
            // Apply the actie color scheme to this element
            if (ColorSchemeManager.Instance != null && ColorSchemeManager.Instance.activeColorScheme != null)
                ColorSchemeManager.Instance.activeColorScheme.ApplyToElement(this);
        }

#if UNITY_EDITOR
        protected void OnValidate()
        {
            // Apply the actie color scheme to this element
            if (ColorSchemeManager.Instance != null && ColorSchemeManager.Instance.activeColorScheme != null)
                ColorSchemeManager.Instance.activeColorScheme.ApplyToElement(this);
        }
#endif
    }
}
