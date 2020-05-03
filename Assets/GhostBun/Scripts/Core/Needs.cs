// using System.Collections.Generic;
//
// public class Needs : INeeds
// {
//     private List<Need> _needs;
//
//     public void AddNeeds(string name, float value)
//     {
//         _needs.Add(new Need(value, name));
//     }
//
//     public IEnumerable<Need> GetNeeds()
//     {
//         return _needs;
//     }
//     
//     public void DecreaseNeedsValue(float value)
//     {
//         foreach (var need in _needs)
//         {
//             need.Value -= value;
//         }
//     }
// }
//
// public class Need
// {
//     public float Value;
//     public string Name;
//
//     public Need(float value, string name)
//     {
//         Value = value;
//         Name = name;
//     }
// }
//
// public interface INeeds
// {
//     IEnumerable<Need> GetNeeds();
// }