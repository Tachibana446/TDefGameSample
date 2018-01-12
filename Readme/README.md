# 自分のための備忘録

# ユニット
![](./readme1.png)
ユニット Unit.cs, Slime.cs, BoxCollider  
└攻撃範囲 RangeCircle.cs  
となっていて Unitクラスに攻撃力・HP・死んだ時手に入るお金などが記載されている  
個々の攻撃（この場合はスライム）についてはSlimeクラスが担当  
子のRangeCircleに必要な情報を渡すと一定間隔で範囲内の敵を攻撃してくれる  

Slime.Start  
↓  
RangeCircle.Init  
↓  
RangeCircle.Update（攻撃） ← Unit.Damage（攻撃力）  

Slime.Update（移動）  

# TODO
- HP表示(option)
- 拠点
- ゲームクリア
- ゲームオーバー
- ユニット購入
