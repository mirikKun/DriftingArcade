using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
   [SerializeField] private int _totalSecondsTime;
   [SerializeField] private UiPoints _uiPoints;
   [SerializeField] private UiTimer _uiTimer;
   [SerializeField] private float _pointsPerSecond;

   private PointsCounter _pointsCounter;
   
   private GameLevelMediator _mediator;
   private CarMover _carMover;
   
   private float _currentTime;
   private bool _timeEnded;

   [Inject]
   private void Construct(GameLevelMediator mediator,CarMover carMover)
   {
      _mediator = mediator;
      _carMover = carMover;
   }
   private void Start()
   {
      ResetGame();
      _carMover.OnDrifting += AddPoints;
   }

   private void Update()
   {
      if(_timeEnded)
         return;
      _currentTime += Time.deltaTime;
      if (_currentTime >= _totalSecondsTime)
      {
        EndGame();
      }
      _uiTimer.UpdateTimer(_currentTime);
   }

   private void AddPoints()
   {
      _pointsCounter.AddDriftingPoints(Time.deltaTime);
      _uiPoints.UpdatePointsText(_pointsCounter.CurrentPoints);
   }
   private void ResetGame()
   {
      _currentTime = 0;
      _pointsCounter = new PointsCounter(_pointsPerSecond);
   }
   private void EndGame()
   {
      _currentTime = _totalSecondsTime;
      _timeEnded = true;
      _mediator.OpenGameEndPanel();
   }
}