#if UNITY_EDITOR
using CustomEditorAttributes;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(PimpingHeader))]
    public class PimpingHeaderDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            PimpingHeader header = (PimpingHeader)attribute;
            
            // Добавляем отступ сверху
            position.y += 5f;
            position.height = header.height;
            
            if (header.useGradient)
            {
                DrawGradientBackground(position, header);
            }
            else
            {
                // Обычный фон
                EditorGUI.DrawRect(position, header.backgroundColor);
            }
            
            // Создаем стиль для текста
            GUIStyle textStyle = new GUIStyle(GUI.skin.label);
            textStyle.normal.textColor = header.textColor;
            textStyle.fontSize = header.fontSize;
            textStyle.alignment = header.alignment;
            textStyle.fontStyle = header.bold ? FontStyle.Bold : FontStyle.Normal;
            
            // Добавляем тень для текста (для лучшей читаемости)
            GUIStyle shadowStyle = new GUIStyle(textStyle);
            shadowStyle.normal.textColor = new Color(0, 0, 0, 0.5f);
            
            // Рисуем тень
            Rect shadowRect = new Rect(position.x + 1, position.y + 1, position.width, position.height);
            GUI.Label(shadowRect, header.headerText, shadowStyle);
            
            // Рисуем основной текст
            GUI.Label(position, header.headerText, textStyle);
            
            // Рисуем рамку
            //DrawBorder(position, header);
        }
        
        private void DrawGradientBackground(Rect position, PimpingHeader header)
        {
            // Создаем градиент с затуханием используя больше шагов для плавности
            int steps = 5000; // Увеличено для более плавного градиента
            
            switch (header.gradientDirection)
            {
                case GradientDirection.Horizontal:
                    DrawHorizontalGradientWithFade(position, header.backgroundColor, header.secondaryColor, steps);
                    break;
                case GradientDirection.Vertical:
                    DrawVerticalGradientWithFade(position, header.backgroundColor, header.secondaryColor, steps);
                    break;
                case GradientDirection.Diagonal:
                    DrawDiagonalGradientWithFade(position, header.backgroundColor, header.secondaryColor, steps);
                    break;
                case GradientDirection.Radial:
                    DrawRadialGradientWithFade(position, header.backgroundColor, header.secondaryColor, steps);
                    break;
            }
        }
        
        private void DrawHorizontalGradientWithFade(Rect position, Color startColor, Color endColor, int steps)
        {
            float stepWidth = position.width / steps;
            
            for (int i = 0; i < steps; i++)
            {
                float t = (float)i / (steps - 1);
                
                // Применяем затухающую функцию для более плавного перехода
                float smoothT = Mathf.SmoothStep(0f, 1f, t);
                
                // Добавляем затухание к краям
                float fadeT = ApplyFadeEffect(t);
                
                Color currentColor = Color.Lerp(startColor, endColor, smoothT);
                currentColor.a *= fadeT; // Применяем затухание к прозрачности
                
                Rect stepRect = new Rect(position.x + i * stepWidth, position.y, stepWidth + 1, position.height);
                EditorGUI.DrawRect(stepRect, currentColor);
            }
        }
        
        private void DrawVerticalGradientWithFade(Rect position, Color startColor, Color endColor, int steps)
        {
            float stepHeight = position.height / steps;
            
            for (int i = 0; i < steps; i++)
            {
                float t = (float)i / (steps - 1);
                float smoothT = Mathf.SmoothStep(0f, 1f, t);
                float fadeT = ApplyFadeEffect(t);
                
                Color currentColor = Color.Lerp(startColor, endColor, smoothT);
                currentColor.a *= fadeT;
                
                Rect stepRect = new Rect(position.x, position.y + i * stepHeight, position.width, stepHeight + 1);
                EditorGUI.DrawRect(stepRect, currentColor);
            }
        }
        
        private void DrawDiagonalGradientWithFade(Rect position, Color startColor, Color endColor, int steps)
        {
            float stepWidth = position.width / steps;
            float stepHeight = position.height / steps;
            
            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < steps; j++)
                {
                    float t = ((float)i + (float)j) / (2 * (steps - 1));
                    t = Mathf.Clamp01(t);
                    
                    float smoothT = Mathf.SmoothStep(0f, 1f, t);
                    float fadeT = ApplyFadeEffect(t);
                    
                    Color currentColor = Color.Lerp(startColor, endColor, smoothT);
                    currentColor.a *= fadeT;
                    
                    Rect stepRect = new Rect(position.x + i * stepWidth, position.y + j * stepHeight, 
                                           stepWidth + 1, stepHeight + 1);
                    EditorGUI.DrawRect(stepRect, currentColor);
                }
            }
        }
        
        private void DrawRadialGradientWithFade(Rect position, Color startColor, Color endColor, int steps)
        {
            Vector2 center = new Vector2(position.x + position.width * 0.5f, position.y + position.height * 0.5f);
            float maxDistance = Mathf.Max(position.width, position.height) * 0.7f; // Уменьшено для лучшего эффекта
            
            int pixelSteps = Mathf.RoundToInt(maxDistance);
            for (int i = 0; i < pixelSteps; i++)
            {
                float t = (float)i / pixelSteps;
                float smoothT = Mathf.SmoothStep(0f, 10f, t);
                float fadeT = ApplyRadialFadeEffect(t);
                
                Color currentColor = Color.Lerp(startColor, endColor, smoothT);
                currentColor.a *= fadeT;
                
                float size = (1f - t) * maxDistance * 2f;
                Rect radialRect = new Rect(center.x - size * 0.5f, center.y - size * 0.25f, size, size * 0.5f);
                
                // Ограничиваем область исходным прямоугольником
                radialRect.x = Mathf.Max(radialRect.x, position.x);
                radialRect.y = Mathf.Max(radialRect.y, position.y);
                radialRect.width = Mathf.Min(radialRect.width, position.width - (radialRect.x - position.x));
                radialRect.height = Mathf.Min(radialRect.height, position.height - (radialRect.y - position.y));
                
                if (radialRect.width > 0 && radialRect.height > 0)
                {
                    EditorGUI.DrawRect(radialRect, currentColor);
                }
            }
        }
        
        // Функция затухания для краев
        private float ApplyFadeEffect(float t)
        {
            // Создаем плавное затухание к краям
            float fadeDistance = 0.45f; // Расстояние затухания (15% от каждого края)
            
            if (t < fadeDistance)
            {
                // Затухание в начале
                return Mathf.SmoothStep(0f, 1f, t / fadeDistance);
            }
            else if (t > 1f - fadeDistance)
            {
                // Затухание в конце
                return Mathf.SmoothStep(0f, 1f, (1f - t) / fadeDistance);
            }
            else
            {
                // Полная непрозрачность в середине
                return 1f;
            }
        }
        
        // Специальная функция затухания для радиального градиента
        private float ApplyRadialFadeEffect(float t)
        {
            // Более плавное затухание для радиального эффекта
            return Mathf.SmoothStep(0f, 1f, 1f - t);
        }
        
        private void DrawBorder(Rect position, PimpingHeader header)
        {
            Color borderColor = new Color(0, 0, 0, 0.3f);
            
            // Верхняя граница
            EditorGUI.DrawRect(new Rect(position.x, position.y, position.width, 1), borderColor);
            // Нижняя граница
            EditorGUI.DrawRect(new Rect(position.x, position.y + position.height - 1, position.width, 1), borderColor);
            // Левая граница
            EditorGUI.DrawRect(new Rect(position.x, position.y, 1, position.height), borderColor);
            // Правая граница
            EditorGUI.DrawRect(new Rect(position.x + position.width - 1, position.y, 1, position.height), borderColor);
        }
        
        public override float GetHeight()
        {
            PimpingHeader header = (PimpingHeader)attribute;
            return header.height + 10f; // +10 для отступов
        }
    }
}
#endif