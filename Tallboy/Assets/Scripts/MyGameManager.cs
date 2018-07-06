using System.Collections;
using System.Collections.Generic;
using TallboyBLL.Presenter;
using UnityEngine;

public class MyGameManager : MonoBehaviour {
    Presenter presenter;

    void Start()
    {
        presenter = Presenter.GetPresenter();
    }

    void OnNextButtonPressed()
    {
        presenter.TaskElementDone();
    }
}
