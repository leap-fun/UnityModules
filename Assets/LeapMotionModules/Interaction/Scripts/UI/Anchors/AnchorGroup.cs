﻿using Leap.Unity.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction {

  [System.Serializable]
  public class AnchorSet : SerializableHashSet<Anchor> { }

  public class AnchorGroup : MonoBehaviour {

    [SerializeField, SHashSet]
    [Tooltip("The anchors that are within this AnchorGroup. Anchorable objects associated "
           + "this AnchorGroup can only be placed in anchors within this group.")]
    private AnchorSet _anchors;
    public AnchorSet anchors { get { return _anchors; } }

    private HashSet<AnchorableBehaviour> _anchorableObjects = new HashSet<AnchorableBehaviour>();
    /// <summary>
    /// Gets the AnchorableBehaviours that are set to this AnchorGroup.
    /// </summary>
    public HashSet<AnchorableBehaviour> anchorableObjects { get { return _anchorableObjects; } }

    void Awake() {
      foreach (var anchor in anchors) {
        Add(anchor);
      }
    }

    public bool Contains(Anchor anchor) {
      return _anchors.Contains(anchor);
    }

    public bool Add(Anchor anchor) {
      if (_anchors.Add(anchor)) {
        anchor.groups.Add(this);
        return true;
      }
      else {
        return false;
      }
    }

    public bool Remove(Anchor anchor) {
      if (_anchors.Remove(anchor)) {
        anchor.groups.Remove(this);
        return true;
      }
      else {
        return false;
      }
    }

    public void NotifyAnchorableObjectAdded(AnchorableBehaviour anchObj) {
      anchorableObjects.Add(anchObj);
    }

    public void NotifyAnchorableObjectRemoved(AnchorableBehaviour anchObj) {
      anchorableObjects.Add(anchObj);
    }

  }

}