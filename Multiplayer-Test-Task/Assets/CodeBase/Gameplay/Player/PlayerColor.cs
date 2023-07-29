using System;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    public struct PlayerColor
    {
        private float _r;
        private float _g;
        private float _b;
        private float _a;

        public PlayerColor(Color color)
        {
            _r = color.r;
            _g = color.g;
            _b = color.b;
            _a = color.a;
        }

        public Color GetValue() => new(_r, _g, _b, _a);

        public static byte[] Serialize(object data)
        {
            var result = new byte[sizeof(float) * 4];
            var color = (PlayerColor)data;

            AddBytes(result, color._r, 0);
            AddBytes(result, color._g, 1);
            AddBytes(result, color._b, 2);
            AddBytes(result, color._a, 3);

            return result;
        }

        public static object Deserialize(byte[] data)
        {
            var result = new PlayerColor
            {
                _r = GetFloat(data, 0),
                _g = GetFloat(data, 1),
                _b = GetFloat(data, 2),
                _a = GetFloat(data, 3)
            };

            return result;
        }

        private static void AddBytes(byte[] array, float data, int index) =>
            BitConverter.GetBytes(data).CopyTo(array, sizeof(float) * index);

        private static float GetFloat(byte[] array, int index) =>
            BitConverter.ToSingle(array, sizeof(float) * index);
    }
}