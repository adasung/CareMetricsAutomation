Feature: Patient Vitals Real-Time Telemetry Routing
  As a Connected Care Central Informatics Server
  I want to process continuous streaming patient vitals from distributed client monitors
  So that critical life-saving alerts are validated and dispatched immediately

  @TelemetryStream @CriticalAlerts
  Scenario: Trigger immediate critical alert for severe oxygen desaturation
    Given a patient client monitor with ID "BED-ICU-04" is active
    When the monitor transmits a streaming real-time vitals payload:
      | HeartRate | SpO2 | RespiratoryRate |
      | 88        | 84   | 12              |
    Then the distributed system response should confirm data ingestion with status code 202