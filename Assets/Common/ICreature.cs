using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public interface ICreature
{
    string creature_title { get; set; }
    string creature_name  { get; set; }
    Color  title_color    { get; set; }
    Color  name_color     { get; set; }
}
