using UnityEngine;

namespace CustomEditorAttributes
{
    public class PimpingHeader : PropertyAttribute
    {
        public string headerText;
        public float height;
        public Color backgroundColor;
        public Color secondaryColor; // Для градиента
        public Color textColor;
        public int fontSize;
        public TextAnchor alignment;
        public bool bold;
        public bool useGradient;
        public GradientDirection gradientDirection;

        // Конструктор с RGB значениями для фона
        public PimpingHeader(string headerText, float r = 0.2f, float g = 0.4f, float b = 0.8f, float a = 0.8f)
        {
            this.headerText = headerText;
            this.backgroundColor = new Color(r, g, b, a);
            this.secondaryColor = new Color(r * 0.7f, g * 0.7f, b * 0.7f, a);
            this.textColor = Color.white;
            this.height = 20f;
            this.fontSize = 12;
            this.alignment = TextAnchor.MiddleCenter;
            this.bold = true;
            this.useGradient = false;
            this.gradientDirection = GradientDirection.Horizontal;
        }

        // Конструктор с предустановленными цветами
        public PimpingHeader(string headerText, HeaderColor color, bool useGradient = true, GradientDirection direction = GradientDirection.Horizontal)
        {
            this.headerText = headerText;
            this.textColor = Color.white;
            this.height = 20f;
            this.fontSize = 12;
            this.alignment = TextAnchor.MiddleCenter;
            this.bold = true;
            this.useGradient = useGradient;
            this.gradientDirection = direction;

            switch (color)
            {
                case HeaderColor.Blue:
                    backgroundColor = new Color(0.2f, 0.4f, 0.8f, 0.9f);
                    secondaryColor = new Color(0.1f, 0.6f, 1f, 0.9f);
                    break;
                case HeaderColor.Red:
                    backgroundColor = new Color(0.8f, 0.2f, 0.2f, 0.9f);
                    secondaryColor = new Color(1f, 0.4f, 0.3f, 0.9f);
                    break;
                case HeaderColor.Green:
                    backgroundColor = new Color(0.2f, 0.7f, 0.3f, 0.9f);
                    secondaryColor = new Color(0.4f, 1f, 0.5f, 0.9f);
                    break;
                case HeaderColor.Orange:
                    backgroundColor = new Color(1f, 0.6f, 0.2f, 0.9f);
                    secondaryColor = new Color(1f, 0.8f, 0.4f, 0.9f);
                    break;
                case HeaderColor.Purple:
                    backgroundColor = new Color(0.6f, 0.3f, 0.8f, 0.9f);
                    secondaryColor = new Color(0.8f, 0.5f, 1f, 0.9f);
                    break;
                case HeaderColor.Pink:
                    backgroundColor = new Color(1f, 0.4f, 0.7f, 0.9f);
                    secondaryColor = new Color(1f, 0.6f, 0.9f, 0.9f);
                    break;
                case HeaderColor.Cyan:
                    backgroundColor = new Color(0.2f, 0.8f, 0.8f, 0.9f);
                    secondaryColor = new Color(0.4f, 1f, 1f, 0.9f);
                    break;
                case HeaderColor.Yellow:
                    backgroundColor = new Color(0.9f, 0.9f, 0.3f, 0.9f);
                    secondaryColor = new Color(1f, 1f, 0.6f, 0.9f);
                    break;
                case HeaderColor.Lime:
                    backgroundColor = new Color(0.5f, 1f, 0.2f, 0.9f);
                    secondaryColor = new Color(0.7f, 1f, 0.4f, 0.9f);
                    break;
                case HeaderColor.Magenta:
                    backgroundColor = new Color(1f, 0.2f, 0.8f, 0.9f);
                    secondaryColor = new Color(1f, 0.5f, 1f, 0.9f);
                    break;
                case HeaderColor.Teal:
                    backgroundColor = new Color(0.2f, 0.6f, 0.6f, 0.9f);
                    secondaryColor = new Color(0.3f, 0.8f, 0.8f, 0.9f);
                    break;
                case HeaderColor.Indigo:
                    backgroundColor = new Color(0.3f, 0.2f, 0.8f, 0.9f);
                    secondaryColor = new Color(0.5f, 0.4f, 1f, 0.9f);
                    break;
                case HeaderColor.Gold:
                    backgroundColor = new Color(1f, 0.8f, 0.2f, 0.9f);
                    secondaryColor = new Color(1f, 0.9f, 0.5f, 0.9f);
                    break;
                case HeaderColor.Silver:
                    backgroundColor = new Color(0.7f, 0.7f, 0.8f, 0.9f);
                    secondaryColor = new Color(0.9f, 0.9f, 1f, 0.9f);
                    break;
                case HeaderColor.Bronze:
                    backgroundColor = new Color(0.8f, 0.5f, 0.2f, 0.9f);
                    secondaryColor = new Color(1f, 0.7f, 0.4f, 0.9f);
                    break;
                case HeaderColor.Crimson:
                    backgroundColor = new Color(0.9f, 0.1f, 0.2f, 0.9f);
                    secondaryColor = new Color(1f, 0.3f, 0.4f, 0.9f);
                    break;
                case HeaderColor.Navy:
                    backgroundColor = new Color(0.1f, 0.2f, 0.5f, 0.9f);
                    secondaryColor = new Color(0.2f, 0.4f, 0.7f, 0.9f);
                    break;
                case HeaderColor.Forest:
                    backgroundColor = new Color(0.1f, 0.4f, 0.2f, 0.9f);
                    secondaryColor = new Color(0.3f, 0.6f, 0.4f, 0.9f);
                    break;
                case HeaderColor.Sunset:
                    backgroundColor = new Color(1f, 0.3f, 0.1f, 0.9f);
                    secondaryColor = new Color(1f, 0.7f, 0.2f, 0.9f);
                    break;
                case HeaderColor.Ocean:
                    backgroundColor = new Color(0.1f, 0.4f, 0.7f, 0.9f);
                    secondaryColor = new Color(0.2f, 0.7f, 0.9f, 0.9f);
                    break;
                case HeaderColor.Galaxy:
                    backgroundColor = new Color(0.2f, 0.1f, 0.4f, 0.9f);
                    secondaryColor = new Color(0.6f, 0.3f, 0.8f, 0.9f);
                    break;
                case HeaderColor.Fire:
                    backgroundColor = new Color(1f, 0.2f, 0.1f, 0.9f);
                    secondaryColor = new Color(1f, 0.6f, 0.1f, 0.9f);
                    break;
                case HeaderColor.Ice:
                    backgroundColor = new Color(0.7f, 0.9f, 1f, 0.9f);
                    secondaryColor = new Color(0.9f, 1f, 1f, 0.9f);
                    textColor = new Color(0.2f, 0.4f, 0.6f);
                    break;
                case HeaderColor.Neon:
                    backgroundColor = new Color(0.2f, 1f, 0.5f, 0.9f);
                    secondaryColor = new Color(0.5f, 1f, 0.8f, 0.9f);
                    break;
                case HeaderColor.Gray:
                    backgroundColor = new Color(0.4f, 0.4f, 0.4f, 0.9f);
                    secondaryColor = new Color(0.6f, 0.6f, 0.6f, 0.9f);
                    break;
                case HeaderColor.Dark:
                    backgroundColor = new Color(0.15f, 0.15f, 0.15f, 0.9f);
                    secondaryColor = new Color(0.3f, 0.3f, 0.3f, 0.9f);
                    break;
                default:
                    backgroundColor = new Color(0.2f, 0.4f, 0.8f, 0.9f);
                    secondaryColor = new Color(0.1f, 0.6f, 1f, 0.9f);
                    break;
            }
        }

        // Расширенный конструктор с градиентом
        public PimpingHeader(string headerText, float bgR, float bgG, float bgB, float bgA,
            float secR, float secG, float secB, float secA,
            float textR = 1f, float textG = 1f, float textB = 1f, 
            float height = 25f, int fontSize = 12, bool bold = true, 
            bool useGradient = true, GradientDirection direction = GradientDirection.Horizontal)
        {
            this.headerText = headerText;
            this.backgroundColor = new Color(bgR, bgG, bgB, bgA);
            this.secondaryColor = new Color(secR, secG, secB, secA);
            this.textColor = new Color(textR, textG, textB, 1f);
            this.height = height;
            this.fontSize = fontSize;
            this.alignment = TextAnchor.MiddleCenter;
            this.bold = bold;
            this.useGradient = useGradient;
            this.gradientDirection = direction;
        }
    }
    
    public enum HeaderColor
    {
        // Основные цвета
        Blue, Red, Green, Orange, Purple, Pink, Cyan, Yellow,
        
        // Дополнительные цвета
        Lime, Magenta, Teal, Indigo, 
        
        // Металлические цвета
        Gold, Silver, Bronze,
        
        // Темные оттенки
        Crimson, Navy, Forest,
        
        // Природные градиенты
        Sunset, Ocean, Galaxy, Fire, Ice,
        
        // Особые эффекты
        Neon,
        
        // Нейтральные
        Gray, Dark
    }
    
    public enum GradientDirection
    {
        Horizontal,
        Vertical,
        Diagonal,
        Radial
    }
}