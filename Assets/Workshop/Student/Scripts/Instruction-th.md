# Assignment 02: การเรียนรู้ Arrays และ Loop Structures สำหรับ Game Development

## 🎯 จุดประสงค์การเรียนรู้

- เรียนรู้การประกาศ การใช้งาน และการจัดการ Arrays
- เข้าใจ for loop และ while loop structures
- นำ Arrays และ Loops มาใช้ร่วมกันในการแก้ปัญหา
- จัดการ array indexing และ array boundaries อย่างปลอดภัย
- นำ Arrays และ Loops มาใช้ในสถานการณ์ game development จริง
- เขียน code ที่สะอาด อ่านง่าย และปฏิบัติตาม best practices

## 📚 โครงสร้างของ Assignment

- **Lecture Methods (7 methods)** - การ implement ฝึกหัดด้วย Arrays และ Loops พื้นฐาน พร้อมกันในห้องเรียน
- **Assignment Methods (16 methods)** - การประยุกต์ใช้ Arrays และ Loops ในสถานการณ์เกม
- **Extra Assignment Method (1 method)** - โจทย์ขั้นสูง (ไม่บังคับ)

## ⚙️ ตัวแปรบน Inspector (สำคัญ)

ทุก method ใน `Lecture.cs` และ `Assignment.cs` **ไม่รับ parameter อีกต่อไป** — ค่าที่เคยเป็น parameter ของแต่ละ method ได้ถูกย้ายไปเป็น public field ของคลาสแทน เพื่อให้กำหนดค่าทดสอบได้จากหน้า Inspector ของ Unity โดยตรง

- แต่ละ field จะขึ้นต้นด้วย prefix ของ method นั้นๆ เช่น method `AS04_AttackEnemy` จะมี field `as04_enemyHP`, `as04_damage`, `as04_target`
- ใน Inspector จะมี `[Header]` คั่นเป็นกลุ่มๆ ตามชื่อ method เพื่อให้แยกกลุ่มตัวแปรของแต่ละโจทย์ได้ง่าย
- เอกสารด้านล่างจะเขียน Method Signature แบบไม่มี parameter (`()`) และแจกแจง field ที่เกี่ยวข้องแยกไว้ในหัวข้อ **ตัวแปร (Inspector Fields)** ของแต่ละ method แทน

### 2D Array บน Inspector: Grid2DInt / Grid2DString

Unity ไม่รองรับการแสดงผล `int[,]` หรือ `string[,]` (rectangular 2D array) บน Inspector โดยตรง ดังนั้น method ที่เดิมรับ 2D array เป็น parameter (LCT06, AS13, AS14, EX_01) จะใช้ field ชนิด `Grid2DInt` หรือ `Grid2DString` แทน ซึ่งเป็น class ที่เขียน custom Inspector ให้กรอกค่าเป็นตาราง (grid) ได้ตรงๆ

เมื่อจะนำไปใช้งานเป็น 2D array จริงในโค้ด ให้เรียก `.Get2DArray()`:
```csharp
int[,] arr = lct06_my2DArray.Get2DArray();       // สำหรับ Grid2DInt
string[,] board = ex01_board.Get2DArray();       // สำหรับ Grid2DString
```

---

## Lecture Methods

Methods เหล่านี้แสดงแนวคิด Arrays และ Loops พื้นฐาน Implement เพื่อฝึกหัดแต่จะไม่มีการให้คะแนน

### 1. LCT01_SyntaxArray

**วัตถุประสงค์:** แสดงการประกาศและใช้งาน Array พื้นฐาน วิธี Get Set และ เข้าถึงขนาดของ Array

**Method Signature:**
```csharp
void LCT01_SyntaxArray()
```

**Logic ที่ต้อง implement:**
- สร้าง string array ขนาด 3 ช่องชื่อ `ironManSuit`
- Set กำหนดค่า: 
   `ironManSuit[0] = "Mark I"`, 
   `ironManSuit[1] = "Mark II"`, 
- สร้างตัวแปร `tonyStarkWear`  Get ดึ่งค่าจาก: `ironManSuit[0]`    
   เพื่อพิมพ์ข้อความ `TonyStark Wear: {tonyStarkWear}`
- Get ขนาดของ array ด้วย .Length และแสดงข้อความ 
   `Room size: {ironManSuit.Length}`
- ทำการ Log ค่า ของ ironManSuit ในช่องที่ 1 และ 2
- แสดงผลค่าต่างๆ ตามรูปแบบที่กำหนด

**Test Case:**
- **Input:** ไม่มี parameters
- **Expected Output:**
```
TonyStark Wear: Mark I
Room size: 2
Mark I
Mark II
```

### 2. LCT02_ArrayInitialize

**วัตถุประสงค์:** แสดงการใช้งานประกาศ array แบบกำหนดขาด และ เซตค่า และการเข้าถึงข้อมูลใน array

**Method Signature:**
```csharp
void LCT02_ArrayInitialize()
```

**Logic ที่ต้อง implement:**
- สร้างชุดข้อมูล array ของ Spider-Man suits โดยกำหนดให้มีค่าดังต่อไปนี้ตามลำดับดังนี้
   "Classic SpiderMan",
   "Black Suit",
   "Iron Spider Suit",
- และ สร้างชุดข้อมูล array ของ Batman suits โดยกำหนดให้มีขนาดเท่ากับ 2 และมีค่าดังต่อไปนี้ตามลำดับดังนี้
    "Classic BatMan",
    "White bat",
- ใช้ array.Length เพื่อแสดงขนาดของ array เพื่อบอกขนาดของห้อง
- และพิมพ์ข้อมูลของ array ทั้ง 2 ตัวตามลำดับ

**Test Case:**
- **Input:** ไม่มี parameters
- **Expected Output:**
```
Room size: 3
Classic SpiderMan
Black Suit
Iron Spider Suit
Room size: 2
Classic BatMan
White bat
```

### 3. LCT03_SyntaxLoop

**วัตถุประสงค์:** แสดงการใช้งาน for loop พื้นฐาน

**Method Signature:**
```csharp
void LCT03_SyntaxLoop()
```

**Logic ที่ต้อง implement:**
- for loop ที่ 1: วนลูป 10 ครั้ง (i = 0 ถึง 9) แสดงข้อความ `"<10 : " + i`
- พิมพ์ `"==="`
- for loop ที่ 2: วนลูป 10 ครั้ง (i = 1 ถึง 10) แสดงข้อความ `"<=10 : " + i`

**ผลลัพธ์ที่คาดหวัง:**
```
<10 : 0
<10 : 1
<10 : 2
...
<10 : 9
===
<=10 : 1
<=10 : 2
...
<=10 : 10
```

### 4. LCT04_LoopAndArray

**วัตถุประสงค์:** แสดงการใช้งาน Array และ for loop ร่วมกัน

**Method Signature:**
```csharp
void LCT04_LoopAndArray()
```

**ตัวแปร (Inspector Fields):**
- `lct04_ironManSuitNames` (`string[]`) - อาร์เรย์ของชื่อชุดเกราะ Iron Man

**Logic ที่ต้อง implement:**
- ใช้ for loop เพิ่มค่า i ทีละ 1 เพื่อแสดงชื่อชุดเกราะทั้งหมด
- พิมพ์ `"==="`
- ใช้ for loop เพิ่มค่า i ทีละ 2 เพื่อแสดงชื่อชุดเกราะทุกๆ 2 ตัว

**Test Case:**
- **Input:** `["Mark I", "Mark II", "Mark III", "Mark IV", "Mark V", "Mark VI", "Mark VII"]`
- **Expected Output:**
```
Mark I
Mark II
Mark III
Mark IV
Mark V
Mark VI
Mark VII
===
Mark I
Mark III
Mark V
Mark VII
```

### 5. LCT05_Syntax2DArray

**วัตถุประสงค์:** แสดงการประกาศและใช้งาน 2D Array

**Method Signature:**
```csharp
void LCT05_Syntax2DArray()
```

**Logic ที่ต้อง implement:**
- สร้าง 2D array ขนาด 2x2 มีค่า `{ {1, 2}, {3, 4} }`
- แสดงผลข้อมูลทั้งหมดใน 2D Array ตามรูปแบบที่กำหนด `my2DArray [0,0] = {my2DArray [0,0]}`
- ทำการแก้ไข้ข้อมูลช่องที่ [0,1] = 6 และ [1,1] = 8
- จากนั้นแสดงข้อความ "After change value"
-  แสดงผลข้อมูลที่แก้ไข 


**Test Case:**
- **Input:** ไม่มี parameters
- **Expected Output:**
```
my2DArray[0, 0] = 1
my2DArray[0, 1] = 2
my2DArray[1, 0] = 3
my2DArray[1, 1] = 4
After change value
my2DArray[0, 1] = 6
my2DArray[1, 1] = 8
```

### 6. LCT06_SizeOf2DArray

**วัตถุประสงค์:** แสดงการหาขนาดของ 2D Array

**Method Signature:**
```csharp
void LCT06_SizeOf2DArray()
```

**ตัวแปร (Inspector Fields):**
- `lct06_my2DArray` (`Grid2DInt`) - อาร์เรย์ 2 มิติ กรอกค่าเป็นตารางได้จาก Inspector เรียก `lct06_my2DArray.Get2DArray()` เพื่อแปลงเป็น `int[,]`

**Logic ที่ต้อง implement:**
- แปลง `lct06_my2DArray` เป็น `int[,]` ด้วย `Get2DArray()`
- ใช้ `.GetLength(0)` เพื่อหาจำนวนแถว
- ใช้ `.GetLength(1)` เพื่อหาจำนวนคอลัมน์
- แสดงผลตามรูปแบบที่กำหนด

**Test Case:**
- **Input:** `lct06_my2DArray` ตั้งค่าเริ่มต้นเป็น 3x5 (`{{1,2,3,4,5}, {1,2,3,4,5}, {1,2,3,4,5}}`) จาก Inspector
- **Expected Output:**
```
rows = 3
cols = 5
```

### 7. LCT07_SyntaxNestedLoop

**วัตถุประสงค์:** แสดงการใช้งาน Nested Loop

**Method Signature:**
```csharp
void LCT07_SyntaxNestedLoop()
```

**ตัวแปร (Inspector Fields):**
- `lct07_columns` (`int`) - จำนวนคอลัมน์
- `lct07_rows` (`int`) - จำนวนแถว

**Logic ที่ต้อง implement:**
- ใช้ nested loop เพื่อสร้าง pattern ดาว (*) ตามขนาดที่กำหนด
- แต่ละแถวจะมีดาวจำนวน columns ดวง
- จำนวนแถวทั้งหมดตาม rows

**Test Cases:**
1. **Input:** `columns=3, rows=4`
   **Expected Output:**
   ```
   ***
   ***
   ***
   ***
   ```

2. **Input:** `columns=10, rows=1`
   **Expected Output:**
   ```
   **********
   ```

3. **Input:** `columns=5, rows=3`
   **Expected Output:**
   ```
   *****
   *****
   *****
   ```

4. **Input:** `columns=1, rows=5`
   **Expected Output:**
   ```
   *
   *
   *
   *
   *
   ```

---

## Assignment Methods

Methods เหล่านี้เป็นการประยุกต์ใช้ Arrays และ Loops ในสถานการณ์เกม และจะมีการให้คะแนน

### AS01_RandomItemDrop

**วัตถุประสงค์:** สุ่มการดรอปไอเท็มในเกม

**Method Signature:**
```csharp
void AS01_RandomItemDrop()
```

**ตัวแปร (Inspector Fields):**
- `as01_items` (`GameObject[]`) - รายการของ GameObject ไอเท็มทั้งหมดที่จะสุ่มดรอป

**Logic ที่ต้อง implement:**
- สุ่มเลือก GameObject จาก array items
- ใช้ `Instantiate()` เพื่อสร้างออบเจกต์
- แสดงชื่อไอเท็มที่ได้รับในรูปแบบ `"Got item: {ชื่อไอเท็ม.name}"`

**Test Cases:**
1. **Input:** `["Sword", "Shield", "Potion"]` (3 items)
   **Expected Output:** `Got item: {หนึ่งในไอเท็มที่กำหนด}`

2. **Input:** `["Helmet"]` (1 item)
   **Expected Output:** `Got item: Helmet`

3. **Input:** `["Bow", "Arrow", "Quiver", "Magic Ring", "Health Potion"]` (5 items)
   **Expected Output:** `Got item: {หนึ่งในไอเท็มที่กำหนด}`

**หมายเหตุ:** ผลลัพธ์จะสุ่มจากรายการที่กำหนด ดังนั้นอาจได้ไอเท็มใดก็ได้ในรายการ

### AS02_NestedLoopForCreate2DMap

**วัตถุประสงค์:** สร้างแผนที่ 2D แบบสุ่มด้วย Nested Loop

**Method Signature:**
```csharp
void AS02_NestedLoopForCreate2DMap()
```

**ตัวแปร (Inspector Fields):**
- `as02_floorTiles` (`GameObject[]`) - อาร์เรย์ของ GameObject พื้นแบบต่างๆ
- `as02_columns` (`int`) - จำนวนคอลัมน์ของแผนที่
- `as02_rows` (`int`) - จำนวนแถวของแผนที่

**Logic ที่ต้อง implement:**
- ใช้ nested loop เพื่อสร้างแผนที่
- ใช้ `Instantiate()` เพื่อสร้างพื้นผิวที่ตำแหน่ง `new Vector2(x, y)`
- โดยทุกครั้งที่สร้างแผ่น Tile ให้ตั้งชื่อวัตถุเป็น `$"[{x}:{y}]"`
- จากนั้นทำการ Log ชื่อของวัตถุออกมา
**Test Cases:**
1. **Input:** `floorTiles=["0", "1", "2"], columns=3, rows=3`
   **Expected Behavior:** สร้าง GameObject จำนวน 9 ตัว (3x3) โดยแต่ละตัวมีชื่อเป็น [0:0], [0:1]...

2. **Input:** `floorTiles=["0", "1"], columns=2, rows=2`
   **Expected Behavior:** สร้าง GameObject จำนวน 4 ตัว (2x2) โดยแต่ละตัวมีชื่อเป็น [0:0], [0:1]...

3. **Input:** `floorTiles=["0", "1", "2"], columns=5, rows=2`
   **Expected Behavior:** สร้าง GameObject จำนวน 10 ตัว (5x2) โดยแต่ละตัวมีชื่อเป็น [0:0], [0:1]...

**หมายเหตุ:** การสุ่มทำให้ pattern ของแผนที่เปลี่ยนแปลงได้ แต่จำนวน GameObject ที่สร้างจะตรงกับ columns × rows เสมอ

### AS03_NestedLoopForMakingWallAround

**วัตถุประสงค์:** สร้างกำแพงรอบนอกแผนที่

**Method Signature:**
```csharp
void AS03_NestedLoopForMakingWallAround()
```

**ตัวแปร (Inspector Fields):**
- `as03_wall` (`GameObject`) - GameObject/Prefab กำแพง
- `as03_columns` (`int`) - จำนวนคอลัมน์ของพื้นที่เล่น
- `as03_rows` (`int`) - จำนวนแถวของพื้นที่เล่น

**Logic ที่ต้อง implement:**
- ตรวจสอบตำแหน่งขอบด้วยเงื่อนไข `if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)`
- สร้างกำแพงในตำแหน่งขอบด้วย `Instantiate(wall, new Vector2(x, y), transform.rotation)`
- โดยทุกครั้งที่สร้างแผ่น Tile ให้ตั้งชื่อวัตถุเป็น `$"[{x}:{y}]"`
- จากนั้นทำการ Log ชื่อของวัตถุออกมา
**Test Case:**
- **Input:** `wall=GameObject("*"), columns=5, rows=3`
- **Expected Behavior:** สร้างกำแพงรอบขอบของพื้นที่ขนาด 5x3
- **Expected Output:** ไม่มี Debug.Log output (method นี้ไม่ต้องพิมพ์อะไร)

**การทำงาน:** Method นี้จะสร้าง GameObject ของกำแพงไว้รอบๆ ขอบของพื้นที่ที่กำหนด

### AS04_AttackEnemy

**วัตถุประสงค์:** ระบบโจมตีศัตรูในเกม

**Method Signature:**
```csharp
void AS04_AttackEnemy()
```

**ตัวแปร (Inspector Fields):**
- `as04_enemyHP` (`int[]`) - array ที่เก็บค่า HP ของ enemy แต่ละตัว
- `as04_damage` (`int`) - จำนวน damage ที่จะโจมตี
- `as04_target` (`int`) - index ของ enemy เป้าหมายที่จะโจมตี (สำหรับรูปแบบที่ 3)

**Logic ที่ต้อง implement:**
- โจมตีศัตรูตัวแรก: `enemyHP[0] -= damage`
- โจมตีศัตรูตัวสุดท้าย: `enemyHP[enemyHP.Length - 1] -= damage`
- โจมตีศัตรูตัวที่ระบุ: `enemyHP[target] -= damage`
- แสดงผล HP ที่เหลือของแต่ละตัว (HP ต่ำสุดคือ 0)

**Test Cases:**
1. **Input:** `enemyHP=[10,15,20,25,30], damage=2, target=3`
   **Expected Output:**
   ```
   FirstEnemy hp :8
   LastEnemy hp :28
   TargetEnemy 3 hp :23
   ```

2. **Input:** `enemyHP=[5,10,15], damage=10, target=1`
   **Expected Output:**
   ```
   FirstEnemy hp :0
   LastEnemy hp :5
   TargetEnemy 1 hp :0
   ```

3. **Input:** `enemyHP=[20], damage=5, target=0`
   **Expected Output:**
   ```
   FirstEnemy hp :15
   LastEnemy hp :10
   TargetEnemy 0 hp :5
   ```

**หมายเหตุ:** HP จะไม่ลดต่ำกว่า 0 และศัตรูตัวเดียวกันอาจถูกโจมตีหลายครั้งหากเป็นทั้ง first/last และ target

### AS05_DynamicIterationLoop

**วัตถุประสงค์:** สร้าง loop ที่มีจำนวนรอบแบบไดนามิก

**Method Signature:**
```csharp
void AS05_DynamicIterationLoop()
```

**ตัวแปร (Inspector Fields):**
- `as05_n` (`int`) - ค่าจำนวนเต็มที่รับจาก inputField (จำนวนรอบที่จะวนลูป)

**Logic ที่ต้อง implement:**
- สร้าง for loop จาก 0 ถึง n-1
- แสดงผลตัวเลขในแต่ละรอบ

**Test Cases:**
1. **Input:** `n=0`
   **Expected Output:** (ไม่มี output)

2. **Input:** `n=1`
   **Expected Output:**
   ```
   0
   ```

3. **Input:** `n=3`
   **Expected Output:**
   ```
   0
   1
   2
   ```

4. **Input:** `n=5`
   **Expected Output:**
   ```
   0
   1
   2
   3
   4
   ```

5. **Input:** `n=10`
   **Expected Output:**
   ```
   0
   1
   2
   3
   4
   5
   6
   7
   8
   9
   ```

### AS06_WhileLoopAndArray

**วัตถุประสงค์:** ใช้ while loop กับ Array

**Method Signature:**
```csharp
void AS06_WhileLoopAndArray()
```

**ตัวแปร (Inspector Fields):**
- `as06_ironManSuitNames` (`string[]`) - อาร์เรย์ของชื่อชุดเกราะ Iron Man

**Logic ที่ต้อง implement:**
- ใช้ while loop เพิ่ม i ทีละ 1 เพื่อแสดงชื่อชุดเกราะทั้งหมด
- พิมพ์ `"==="`
- ใช้ while loop เพิ่ม i ทีละ 2 เพื่อแสดงชื่อชุดเกราะทุกๆ 2 ตัว

**Test Case:**
- **Input:** `["Mark I", "Mark II", "Mark III", "Mark IV", "Mark V", "Mark VI", "Mark VII"]`
- **Expected Output:**
```
Mark I
Mark II
Mark III
Mark IV
Mark V
Mark VI
Mark VII
===
Mark I
Mark III
Mark V
Mark VII
```

### AS07_HealTargetAtIndex

**วัตถุประสงค์:** ระบบฟื้นฟู HP ของ Hero

**Method Signature:**
```csharp
void AS07_HealTargetAtIndex()
```

**ตัวแปร (Inspector Fields):**
- `as07_heroHPs` (`int[]`) - array ที่เก็บค่า HP ของ hero แต่ละตัว
- `as07_heal` (`int`) - จำนวน heal ที่จะฟื้นฟู
- `as07_targetIndex` (`int`) - index ของ hero เป้าหมายที่จะฟื้นฟู (สำหรับรูปแบบที่ 3)

**Logic ที่ต้อง implement:**
- Heal Hero ตัวแรก: `heroHPs[0] += heal`
- Heal Hero ตัวสุดท้าย: `heroHPs[heroHPs.Length - 1] += heal`
- Heal Hero ตัวที่ระบุ: `heroHPs[targetIndex] += heal`
- แสดงผล HP หลังจาก heal

**Test Cases:**
1. **Input:** `heroHPs=[10,15,20,25,30], heal=5, targetIndex=3`
   **Expected Output:**
   ```
   FirstHero hp :15
   LastHero hp :35
   TargetHero 3 hp :30
   ```

2. **Input:** `heroHPs=[1,2,3], heal=10, targetIndex=1`
   **Expected Output:**
   ```
   FirstHero hp :11
   LastHero hp :13
   TargetHero 1 hp :12
   ```

3. **Input:** `heroHPs=[100], heal=50, targetIndex=0`
   **Expected Output:**
   ```
   FirstHero hp :150
   LastHero hp :200
   TargetHero 0 hp :250
   ```

**หมายเหตุ:** Hero ตัวเดียวกันอาจถูก heal หลายครั้งหากเป็นทั้ง first/last และ target

### AS08_RandomPickingDialogue

**วัตถุประสงค์:** ระบบบทสนทนาแบบสุ่ม

**Method Signature:**
```csharp
void AS08_RandomPickingDialogue()
```

**ตัวแปร (Inspector Fields):**
- `as08_dialogues` (`string[]`) - Array ที่เก็บชุดข้อความบทสนทนาทั้งหมด

**Logic ที่ต้อง implement:**
- สุ่มเลือกบทสนทนาจาก array โดยใช้ `UnityEngine.Random.Range(0, dialogues.Length)`
- แสดงบทสนทนาที่สุ่มได้

**Test Cases:**
1. **Input:** `["สวัสดีครับ", "คุณเป็นอย่างไรบ้าง", "มีอะไรให้ช่วยไหม"]`
   **Expected Output:** หนึ่งใน 3 ข้อความที่กำหนด

2. **Input:** `["Hello there!", "How are you?", "What can I do for you?"]`
   **Expected Output:** หนึ่งใน 3 ข้อความที่กำหนด

3. **Input:** `["Welcome!"]`
   **Expected Output:** `Welcome!`

4. **Input:** `["Good morning", "Good afternoon", "Good evening", "Good night", "See you later"]`
   **Expected Output:** หนึ่งใน 5 ข้อความที่กำหนด

**หมายเหตุ:** ผลลัพธ์จะสุ่มจากรายการที่กำหนด ดังนั้นอาจได้ข้อความใดก็ได้ในรายการ

### AS09_MultiplicationTable

**วัตถุประสงค์:** สร้างตารางสูตรคูณ

**Method Signature:**
```csharp
void AS09_MultiplicationTable()
```

**ตัวแปร (Inspector Fields):**
- `as09_n` (`int`) - แม่สูตรคูณที่ต้องการสร้าง (จำนวนเต็มจากช่อง inputField)

**Logic ที่ต้อง implement:**
- สร้าง for loop จาก 1 ถึง 12
- แสดงผลในรูปแบบ `"{n}x{i}={n*i}"`

**Test Cases:**
1. **Input:** `n=1`
   **Expected Output:**
   ```
   1x1=1
   1x2=2
   1x3=3
   1x4=4
   1x5=5
   1x6=6
   1x7=7
   1x8=8
   1x9=9
   1x10=10
   1x11=11
   1x12=12
   ```

2. **Input:** `n=5`
   **Expected Output:**
   ```
   5x1=5
   5x2=10
   5x3=15
   5x4=20
   5x5=25
   5x6=30
   5x7=35
   5x8=40
   5x9=45
   5x10=50
   5x11=55
   5x12=60
   ```

3. **Input:** `n=0`
   **Expected Output:**
   ```
   0x1=0
   0x2=0
   0x3=0
   0x4=0
   0x5=0
   0x6=0
   0x7=0
   0x8=0
   0x9=0
   0x10=0
   0x11=0
   0x12=0
   ```

### AS10_FindSummationFromOneToNUsingWhileLoop

**วัตถุประสงค์:** หาผลรวมตัวเลขด้วย while loop

**Method Signature:**
```csharp
void AS10_FindSummationFromZeroToNUsingWhileLoop()
```

**ตัวแปร (Inspector Fields):**
- `as10_n` (`int`) - จำนวนเต็มที่ผู้ใช้ป้อนเข้ามา

**Logic ที่ต้อง implement:**
- ใช้ while loop เพื่อบวกตัวเลขจาก 0 ถึง n (สูตร: sum = 0 + 1 + 2 + ... + n)
- แสดงผลรวมในรูปแบบ `"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}"`

**Test Cases:**
1. **Input:** `n=0`
   **Expected Output:** `ผลรวมของ n จาก 0 ถึง 0 คือ 0`

2. **Input:** `n=1`
   **Expected Output:** `ผลรวมของ n จาก 0 ถึง 1 คือ 1`

3. **Input:** `n=5`
   **Expected Output:** `ผลรวมของ n จาก 0 ถึง 5 คือ 15`

4. **Input:** `n=10`
   **Expected Output:** `ผลรวมของ n จาก 0 ถึง 10 คือ 55`

5. **Input:** `n=100`
   **Expected Output:** `ผลรวมของ n จาก 0 ถึง 100 คือ 5050`

**หมายเหตุ:** สูตรคำนวณ: sum = n × (n + 1) ÷ 2

### AS11_SpawnEnemies

**วัตถุประสงค์:** สร้างศัตรูหลายตัวตามตำแหน่งที่กำหนด

**Method Signature:**
```csharp
void AS11_SpawnEnemies()
```

**ตัวแปร (Inspector Fields):**
- `as11_enemyHPs` (`int[]`) - อาร์เรย์ของค่า HP ศัตรูแต่ละตัว
- `as11_enemyPrefab` (`GameObject`) - Prefab ของศัตรูที่จะสร้าง

**Logic ที่ต้อง implement:**
- ใช้ for loop เพื่อสร้างศัตรูตามจำนวนใน array enemyHPs
- กำหนดตำแหน่งศัตรูให้ห่างจากกันในแกน X
- ตำแหน่งศัตรูตัวที่ i อยู่ที่ `new Vector2(i+1, 0)`
- แสดงตำแหน่งแต่ละตัวในรูปแบบ `"new enemy at position x = {x}"`

**Test Cases:**
1. **Input:** `enemyHPs=[100], enemyPrefab=GameObject("EnemyPrefab")`
   **Expected Output:**
   ```
   new enemy at position x = 1
   ```

2. **Input:** `enemyHPs=[50,75], enemyPrefab=GameObject("EnemyPrefab")`
   **Expected Output:**
   ```
   new enemy at position x = 1
   new enemy at position x = 2
   ```

3. **Input:** `enemyHPs=[25,50,75,100], enemyPrefab=GameObject("EnemyPrefab")`
   **Expected Output:**
   ```
   new enemy at position x = 1
   new enemy at position x = 2
   new enemy at position x = 3
   new enemy at position x = 4
   ```

**หมายเหตุ:** จำนวนศัตรูที่สร้างจะเท่ากับความยาวของ array enemyHPs

### AS12_CountTime

**วัตถุประสงค์:** เคลื่อนย้าย Object ในแกน X

**Method Signature:**
```csharp
IEnumerator AS12_CountTime()
```

**ตัวแปร (Inspector Fields):**
- `as12_countTime` (`float`) - เวลาที่ต้องการนับถอยหลัง / จับเวลา (วินาที)

**Logic ที่ต้อง implement:**
- ใช้ while loop เพื่อ0yจับเวลา
- จับเวลาด้วย `Time.deltaTime)`
- แสดงข้อความเวลาในปัจจุบัน ทศนิยม 2 ตำแหน่ง `"timer : {timer.ToString("F2")}`

**Test Cases:**
1. **Input:** `CountTime =0.0f`
   **Expected Output:**
   ```
   End timer : 0
   ```

2. **Input:** `CountTime = 1f`
   **Expected Output:**
   ```
   timer : 0.10
   timer : 0.20
   timer : 0.30
   timer : 0.40
   timer : 0.50
   timer : 0.60
   timer : 0.70
   timer : 0.80
   timer : 0.90
   timer : 1.00
   End timer : 1
   ```

3. **Input:** `CountTime = 1.5f`
   **Expected Output:** 
   ```
   timer : 0.10
   timer : 0.20
   timer : 0.30
   timer : 0.40
   timer : 0.50
   timer : 0.60
   timer : 0.70
   timer : 0.80
   timer : 0.90
   timer : 1.00
   timer : 1.10
   timer : 1.20
   timer : 1.30
   timer : 1.40
   timer : 1.50
   End timer : 1.50
   ```

### AS13_SumOfNumbersInRow

**วัตถุประสงค์:** หาผลรวมของตัวเลขในแถวของในแนวนอน 2D Array

**Method Signature:**
```csharp
void AS13_SumOfNumbersInRow()
```

**ตัวแปร (Inspector Fields):**
- `as13_matrix` (`Grid2DInt`) - 2D array ที่เก็บตัวเลข กรอกค่าเป็นตารางได้จาก Inspector เรียก `as13_matrix.Get2DArray()` เพื่อแปลงเป็น `int[,]`
- `as13_row` (`int`) - ดัชนีของแถว (Row) ที่ต้องการหาผลรวม

**Logic ที่ต้อง implement:**
- แปลง `as13_matrix` เป็น `int[,]` ด้วย `Get2DArray()`
- ใช้ for loop เพื่อบวกตัวเลขในแถวที่ระบุ
- แสดงผลรวม

**Test Cases:**
`as13_matrix` ตั้งค่าเริ่มต้นเป็น `{{1,2,3}, {4,5,6}, {7,8,9}}` จาก Inspector

1. **Input:** `as13_row=0`
   **Expected Output:** `6` (1+2+3)

2. **Input:** `as13_row=1`
   **Expected Output:** `15` (4+5+6)

3. **Input:** `as13_row=2`
   **Expected Output:** `24` (7+8+9)

### AS14_SumOfNumbersInColumn

**วัตถุประสงค์:** หาผลรวมของตัวเลขในคอลัมน์ของในแนวตั้ง 2D Array

**Method Signature:**
```csharp
void AS14_SumOfNumbersInColumn()
```

**ตัวแปร (Inspector Fields):**
- `as14_matrix` (`Grid2DInt`) - 2D array ที่เก็บตัวเลข กรอกค่าเป็นตารางได้จาก Inspector เรียก `as14_matrix.Get2DArray()` เพื่อแปลงเป็น `int[,]`
- `as14_column` (`int`) - ดัชนีของคอลัมน์ (Column) ที่ต้องการหาผลรวม

**Logic ที่ต้อง implement:**
- แปลง `as14_matrix` เป็น `int[,]` ด้วย `Get2DArray()`
- ใช้ for loop เพื่อบวกตัวเลขในคอลัมน์ที่ระบุ
- แสดงผลรวม

**Test Cases:**
`as14_matrix` ตั้งค่าเริ่มต้นเป็น `{{1,2,3}, {4,5,6}, {7,8,9}}` จาก Inspector

1. **Input:** `as14_column=0`
   **Expected Output:** `12` (1+4+7)

2. **Input:** `as14_column=1`
   **Expected Output:** `15` (2+5+8)

3. **Input:** `as14_column=2`
   **Expected Output:** `18` (3+6+9)

### AS15_MakeTheTriangle

**วัตถุประสงค์:** สร้างรูปสามเหลี่ยมด้วย Nested Loop

**Method Signature:**
```csharp
void AS15_MakeTheTriangle()
```

**ตัวแปร (Inspector Fields):**
- `as15_size` (`int`) - ความสูง / ขนาดของรูปสามเหลี่ยม

**Logic ที่ต้อง implement:**
- ใช้ nested loop เพื่อสร้างรูปสามเหลี่ยม
- ในแต่ละแถว i จะมีดาว i ดวง

**Test Cases:**
1. **Input:** `size=1`
   **Expected Output:**
   ```
   *
   ```

2. **Input:** `size=3`
   **Expected Output:**
   ```
   *
   **
   ***
   ```

3. **Input:** `size=5`
   **Expected Output:**
   ```
   *
   **
   ***
   ****
   *****
   ```

4. **Input:** `size=7`
   **Expected Output:**
   ```
   *
   **
   ***
   ****
   *****
   ******
   *******
   ```

### AS16_MultiplicationTableOf_2_3_and_4

**วัตถุประสงค์:** สร้างตารางสูตรคูณของ 2, 3, และ 4

**Method Signature:**
```csharp
void AS16_MultiplicationTableOf_2_3_and_4()
```

**Logic ที่ต้อง implement:**
- ใช้ nested loop เพื่อสร้างตารางสูตรคูณ
- แสดงผลในรูปแบบตาราง 3 คอลัมน์
- ใช้ `\t` เพื่อแยกคอลัมน์

**Test Case:**
- **Input:** ไม่มี parameters
- **Expected Output:**
```
2 x 1 = 2	3 x 1 = 3	4 x 1 = 4
2 x 2 = 4	3 x 2 = 6	4 x 2 = 8
2 x 3 = 6	3 x 3 = 9	4 x 3 = 12
2 x 4 = 8	3 x 4 = 12	4 x 4 = 16
2 x 5 = 10	3 x 5 = 15	4 x 5 = 20
2 x 6 = 12	3 x 6 = 18	4 x 6 = 24
2 x 7 = 14	3 x 7 = 21	4 x 7 = 28
2 x 8 = 16	3 x 8 = 24	4 x 8 = 32
2 x 9 = 18	3 x 9 = 27	4 x 9 = 36
2 x 10 = 20	3 x 10 = 30	4 x 10 = 40
2 x 11 = 22	3 x 11 = 33	4 x 11 = 44
2 x 12 = 24	3 x 12 = 36	4 x 12 = 48
```

---

## Extra Assignment Method (ไม่บังคับ)

### EX_01_TicTacToeGame_TurnPlay

**วัตถุประสงค์:** จำลองเกม Tic-Tac-Toe (XO)

**Method Signature:**
```csharp
void EX_01_TicTacToeGame_TurnPlay()
```

**ตัวแปร (Inspector Fields):**
- `ex01_board` (`Grid2DString`) - กระดาน Tic Tac Toe ขนาด 3x3 กรอกค่าเป็นตารางได้จาก Inspector เรียก `ex01_board.Get2DArray()` เพื่อแปลงเป็น `string[,]`
- `ex01_playerTurn` (`string`) - ตาของผู้เล่น "X" หรือ "O"
- `ex01_row` (`int`) - แถวที่ต้องการเล่น (index 0 - 2)
- `ex01_column` (`int`) - คอลัมน์ที่ต้องการเล่น (index 0 - 2)

**Logic ที่ต้อง implement:**
- แปลง `ex01_board` เป็น `string[,]` ด้วย `Get2DArray()`
- ตรวจสอบความถูกต้องของการเล่น
- อัพเดทกระดาน
- ตรวจสอบผู้ชนะ
- แสดงกระดานและสถานะเกม

**สถานะที่เป็นไปได้:**
- `">> X wins!"` - ผู้เล่น X ชนะ
- `">> O wins!"` - ผู้เล่น O ชนะ
- `">> Draw"` - เสมอ
- `">> Continue"` - เกมยังไม่จบ
- `">> Invalid move"` - การเล่นผิดกฎ

**Test Cases ตัวอย่าง:**
1. **Valid Move:**
   - **Input:** `board="___,___,___", player="X", row=0, column=0`
   - **Expected Output:**
   ```
   -------------
   | X |   |   |
   -------------
   |   |   |   |
   -------------
   |   |   |   |
   -------------
   
   >> Continue
   ```

2. **Row Win:**
   - **Input:** `board="XX_,OO_,___", player="X", row=0, column=2`
   - **Expected Output:**
   ```
   -------------
   | X | X | X |
   -------------
   | O | O |   |
   -------------
   |   |   |   |
   -------------
   
   >> X wins!
   ```

3. **Column Win:**
   - **Input:** `board="X__,X__,___", player="X", row=2, column=0`
   - **Expected Output:**
   ```
   -------------
   | X |   |   |
   -------------
   | X |   |   |
   -------------
   | X |   |   |
   -------------
   
   >> X wins!
   ```

4. **Diagonal Win:**
   - **Input:** `board="O_X,_O_,___", player="O", row=2, column=2`
   - **Expected Output:**
   ```
   -------------
   | O |   | X |
   -------------
   |   | O |   |
   -------------
   |   |   | O |
   -------------
   
   >> O wins!
   ```

5. **Draw:**
   - **Input:** `board="XOX,OXO,OX_", player="O", row=2, column=2`
   - **Expected Output:**
   ```
   -------------
   | X | O | X |
   -------------
   | O | X | O |
   -------------
   | O | X | O |
   -------------
   
   >> Draw
   ```

6. **Invalid Move:**
   - **Input:** `board="X__,___,___", player="O", row=0, column=0`
   - **Expected Output:**
   ```
   -------------
   | X |   |   |
   -------------
   |   |   |   |
   -------------
   |   |   |   |
   -------------
   
   >> Invalid move
   ```

**หมายเหตุ:**
- `"___,___,___"` แทน board ว่าง (`_` = ช่องว่าง)
- `"X__,___,___"` แทน board ที่มี X ที่ตำแหน่ง (0,0)
- Format การแสดงกระดานต้องตรงกับที่กำหนดเป๊ะๆ รวมทั้งการเว้นวรรคและบรรทัดว่าง

---

## 💡 คำแนะนำในการทำ Assignment

### การใช้ Debug.Log()
- ใช้ `Debug.Log()` สำหรับแสดงผลลัพธ์
- ระวังการเว้นวรรคและการขึ้นบรรทัดใหม่ให้ตรงกับที่คาดหวัง
- ใช้ `$"..."` สำหรับ string interpolation

### การทำงานกับ Arrays
- ใช้ `array.Length` เพื่อหาขนาดของ array
- ระวัง Array Index out of bounds
- ใช้ `array.GetLength(dimension)` สำหรับ 2D arrays

### การทำงานกับ Loops
- ใช้ for loop เมื่อทราบจำนวนรอบที่แน่นอน
- ใช้ while loop เมื่อต้องการวนจนกว่าเงื่อนไขจะเป็นเท็จ
- ระวัง infinite loop

### การสุ่มใน Unity
- ใช้ `UnityEngine.Random.Range(min, max)` สำหรับการสุ่ม
- ค่า max จะไม่รวมในผลลัพธ์ (exclusive)

### การทำงานกับ GameObjects
- ใช้ `Instantiate(prefab, position, rotation)` เพื่อสร้าง GameObject
- ใช้ `gameObject.name` เพื่อดูชื่อของ GameObject

---

## 🔍 การตรวจสอบและ Debug

### วิธีการ Test
1. เรียกใช้ method ที่ต้องการทดสอบ
2. ตรวจสอบ output ใน Console
3. เปรียบเทียบกับผลลัพธ์ที่คาดหวัง

### ข้อผิดพลาดที่พบบ่อย
- การนับ Array index ผิด (เริ่มที่ 0)
- การใช้ < แทน <= ใน loop condition
- การลืมขึ้นบรรทัดใหม่หรือเว้นวรรค
- การใช้ Random ผิด namespace

### เทคนิคการ Debug
- ใช้ `Debug.Log()` เพื่อแสดงค่าตัวแปรระหว่างการทำงาน
- ตรวจสอบเงื่อนไขใน loop และ if statement
- ใช้ Visual Studio debugger เพื่อ step through code

---

## 📝 หมายเหตุ

- Assignment นี้เน้นการฝึกฝนพื้นฐาน Arrays และ Loops
- แต่ละ method ต้องให้ผลลัพธ์ตรงกับ test case อย่างแม่นยำ
- สามารถ implement method ไหนก่อนก็ได้ ไม่จำเป็นต้องเรียงลำดับ
- หากมีข้อสงสัย ให้ปรึกษาอาจารย์หรือผู้ช่วยสอน

**ขอให้โชคดีกับการทำ Assignment! 🎮**
