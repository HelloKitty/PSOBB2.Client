using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DuloGames.UI
{
    public class ColorScheme : ScriptableObject
    {
        [Header("Image Colors")]
        [SerializeField] private Color m_ImageLight = Color.white;
        [SerializeField] private Color m_ImageLightest = Color.white;
        [SerializeField] private Color m_ImageDark = Color.white;
        [SerializeField] private Color m_ImageDarkest = Color.white;
        [SerializeField] private Color m_ImageTribal = Color.white;

        [Header("Button Colors")]
        [SerializeField] private Color m_Button = Color.white;

        [Header("Window Colors")]
        [SerializeField] private Color m_WindowHeader = Color.white;

        [Header("Link Colors")]
        [SerializeField] private ColorBlock m_LinkColors = ColorBlock.defaultColorBlock;

        /// <summary>
        /// Gets or sets the light shade image color.
        /// </summary>
        public Color imageLight
        {
            get { return this.m_ImageLight; }
            set { this.m_ImageLight = value; }
        }

        /// <summary>
        /// Gets or sets the lightest shade image color.
        /// </summary>
        public Color imageLightest
        {
            get { return this.m_ImageLightest; }
            set { this.m_ImageLightest = value; }
        }

        /// <summary>
        /// Gets or sets the dark shade image color.
        /// </summary>
        public Color imageDark
        {
            get { return this.m_ImageDark; }
            set { this.m_ImageDark = value; }
        }

        /// <summary>
        /// Gets or sets the darkest shade image color.
        /// </summary>
        public Color imageDarkest
        {
            get { return this.m_ImageDarkest; }
            set { this.m_ImageDarkest = value; }
        }

        /// <summary>
        /// Gets or sets the tribal image color.
        /// </summary>
        public Color imageTribal
        {
            get { return this.m_ImageTribal; }
            set { this.m_ImageTribal = value; }
        }
        
        /// <summary>
        /// Gets or sets the button color.
        /// </summary>
        public Color button
        {
            get { return this.m_Button; }
            set { this.m_Button = value; }
        }

        /// <summary>
        /// Gets or sets the window header color.
        /// </summary>
        public Color windowHeader
        {
            get { return this.m_WindowHeader; }
            set { this.m_WindowHeader = value; }
        }
        
        /// <summary>
        /// Gets or sets the link color block.
        /// </summary>
        public ColorBlock linkColors
        {
            get { return this.m_LinkColors; }
            set { this.m_LinkColors = value; }
        }

        /// <summary>
        /// Applies the color scheme.
        /// </summary>
        public void ApplyColorScheme()
        {
            // Get all the color scheme elements in the scene
            ColorSchemeElement[] elements = Object.FindObjectsOfType<ColorSchemeElement>();

            foreach (ColorSchemeElement element in elements)
            {
                this.ApplyToElement(element);
            }

            // Set the color scheme as active
            if (ColorSchemeManager.Instance != null)
                ColorSchemeManager.Instance.activeColorScheme = this;
        }

        /// <summary>
        /// Applies the color scheme to the specified element.
        /// </summary>
        /// <param name="element"></param>
        public void ApplyToElement(ColorSchemeElement element)
        {
            if (element == null)
                return;

            // Handle image type
            if (element.elementType == ColorSchemeElementType.Image)
            {
                // Get the image
                Image image = element.gameObject.GetComponent<Image>();
                Color newColor = Color.white;

                if (image != null)
                {
                    switch (element.shade)
                    {
                        case ColorSchemeShade.Light:
                            newColor = this.m_ImageLight;
                            break;
                        case ColorSchemeShade.Lightest:
                            newColor = this.m_ImageLightest;
                            break;
                        case ColorSchemeShade.Dark:
                            newColor = this.m_ImageDark;
                            break;
                        case ColorSchemeShade.Darkest:
                            newColor = this.m_ImageDarkest;
                            break;
                        case ColorSchemeShade.Tribal:
                            newColor = this.m_ImageTribal;
                            break;
                        case ColorSchemeShade.Button:
                            newColor = this.m_Button;
                            break;
                        case ColorSchemeShade.WindowHeader:
                            newColor = this.m_WindowHeader;
                            break;
                    }

                    // Keep the image alpha
                    image.color = new Color(newColor.r, newColor.g, newColor.b, image.color.a);

#if UNITY_EDITOR
                    if (!Application.isPlaying)
                        EditorUtility.SetDirty(image);
#endif
                }
            }
            // Handle link type
            else if (element.elementType == ColorSchemeElementType.Link)
            {
                // Get the button
                Button button = element.gameObject.GetComponent<Button>();

                if (button != null)
                {
                    button.colors = this.m_LinkColors;

#if UNITY_EDITOR
                    if (!Application.isPlaying)
                        EditorUtility.SetDirty(button);
#endif
                }
            }
        }
    }
}
