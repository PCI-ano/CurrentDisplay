# CurrentDisplay
注意：現時点では、まだ通信のセキュリティ対策を実装していません。

## 概要
こちらは個人で開発を行っている「電気使い過ぎ防止システム」で利用する確認通知ソフトです。
センサーからネットワーク経由で電流データを受け取り、画面に表示します。
また、電流値があらかじめ設定しておいた値を超えると画面や音で電気の使い過ぎを警告します。

### 電気使い過ぎ防止システムとは？
「電気使い過ぎ防止システム」は、電気の使い過ぎにより家庭や施設のブレーカーが落ちることを未然に防ぐための仕組みです。
学校で授業を受けている際、ブレーカーが落ちて授業が止まってしまうことが多いことがきっかけで開発に着手しました。

### 電気使い過ぎ防止システムの機能
使い過ぎを防止したい箇所の電気配線に専用のセンサー機器を設置し電流を定期的に測定します。
そして、電流の測定値が基準値を上回った際に、PCで利用できる確認通知ソフトから電気の使い過ぎを警告します。
警告は画面や音によるもので、施設利用者に対し電気使用量削減を促します。

## 機能

* 電流値表示機能：センサーから受け取った電流値を基に、様々な情報を表示します
  * 現在の電流値の表示
  * 電流使用率の表示（使用率…電流制限値に対する現在の電流値の割合）
  * 電流使用率に応じた状態メッセージの表示（正常・注意・警告）
  * 測定データの取得時間
* 電気使い過ぎ警告機能：電流値があらかじめ設定しておいた制限値に対し一定の割合を超えた場合に、画面の変化により警告を行います。

## 動作環境

* OS:Windows

## 使い方
### 使用手順

1. [通知設定](#通知設定)を行い、電流制限や警告・注意を行う電流使用率を設定します。
2. パソコン本体やネットワーク機器の設定で、パソコンのIPアドレスを固定します。
3. ソフトを起動します。起動後にWindowsセキュリティの画面が出る場合は「許可」を押してください（許可しない場合、電流データを受け取れません）。
4. センサーを設定した後電気配線に取り付け、電源を入れます。
5. センサーから電流データを受け取ると画面に情報が表示されます。

### 通知設定
実行ファイルと同階層にあるファイル"CurrentDisplay.dll.config"を編集します。
`<LIMIT>`に電流制限値[A]、`<CAUTION_RATE>`に画面に注意表示する電流使用率[%]、`<WARNING_RATE>`に警告を行う電流使用率[%]をそれぞれ入力します。
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="measurement_current_limit" value="<LIMIT>"/>
		<add key="measurement_caution_use_rate" value="<CAUTION_RATE>"/>
		<add key="measurement_warning_use_rate" value="<WARNING_RATE>"/>
	</appSettings>
</configuration>
```
通知設定については、今後ソフト内で設定できるよう改善予定です。
