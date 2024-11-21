## Công nghệ sử dụng
.NET MVC, entity framework,sql server

## Mô tả ứng dụng 
1. Ứng dụng quản lý khách sạn có quản lý phòng, dịch vụ, nhân viện, hóa đơn, ....
2. Có phân chia role người dùng (khách có thể đặt online, hoặt trực tiếp tại khách sạn)

## Cách setup project
Demo: https://www.youtube.com/watch?v=79xL04T3RMM&t=2s&ab_channel=CounterLogic
1. Tải file zip hoặc git clone 
![image](https://github.com/user-attachments/assets/0edbb1a6-6e36-4152-9030-a08170749a79)

2. Mở project bằng Visualt studio hoặc VS code <br>
Tại terminal nhập ```dotnet ef database update``` để tạo database <br>
Neu các bạn bị lỗi khi nhập lệnh này thì do các bạn chưa cài ef, cài bằng lệnh ```dotnet tool install --global dotnet-ef --version 9.0.0```
![image](https://github.com/user-attachments/assets/ba03b54c-cbea-499d-a767-c757b340a66d)

3. Mở SQL server <br>
   ![image](https://github.com/user-attachments/assets/b54a217f-2da5-435b-992f-27f66412054f)
   <br>
 Ta sẽ thấy database Hotel <br>
![image](https://github.com/user-attachments/assets/ecd29dd2-0a8d-489b-9755-fd98626256d0)

4. Trong project ta vừa download về ở bước 1 có file ```dulieu.sql``` <br>
![image](https://github.com/user-attachments/assets/085fea68-e470-4ed6-91f4-90773b70de80)

Mở lên bằng sql server và chọn database ```hotel``` và nhấn F5 để execute file sql để nạp dữ liệu
![image](https://github.com/user-attachments/assets/ae10984d-3c32-452b-b1f4-9ac5fdce3fb2)

5. Done ta chỉ cần chạy dự án là xong





## Một số hình ảnh của web
![image](https://github.com/user-attachments/assets/c2a8b47e-6a6e-4c2c-b040-4f1f532dea15)

![image](https://github.com/user-attachments/assets/2c643b68-e0a6-42b4-ad85-8cd7bb394c7d)

![image](https://github.com/user-attachments/assets/97dfad30-7a7e-4b84-8222-81e26cd5dce1)

## xem phòng (khi chưa đăng nhập)
![image](https://github.com/user-attachments/assets/4fe94605-2fc7-4696-a4fd-9e4fc1d1b1a3)
>> có thể lọc theo loại phòng hoặc trạng thái phòng

Phòng đơn
![image](https://github.com/user-attachments/assets/6b4baad3-4e4f-41a7-bf16-cd2a56a3663f)
Phòng đôi
![image](https://github.com/user-attachments/assets/6ba958d8-a500-4dd4-a5b4-af038325e6e7)
Phòng gia đình
![image](https://github.com/user-attachments/assets/e811d894-fb33-4096-8a68-a3f9e02a9d8d)


## giao diện khi login (tài khoản admin)(dành cho khách đặt phòng trực tiếp)

![image](https://github.com/user-attachments/assets/bfd5b1da-003c-4c66-9a0f-c9c0ad23d2eb)

Đặt phòng
![image](https://github.com/user-attachments/assets/de6ce2f0-56f6-448c-915b-94a77b8479d0)

lọc các phòng đang thuê

![image](https://github.com/user-attachments/assets/201d5a71-5e85-4f3d-83c1-eaf626d62882)

thanh toán

![image](https://github.com/user-attachments/assets/7949dbe3-cef8-4686-a495-90a2828b0156)

in hóa đơn
![image](https://github.com/user-attachments/assets/3fd8b401-9cd8-4524-9be2-021449567362)

xác nhận checkout 
![image](https://github.com/user-attachments/assets/6ddf5377-176c-4c7e-912b-2b98b4f99f4d)

## giao diện admin quản lý phòng
![image](https://github.com/user-attachments/assets/63b1af18-760f-4cb8-adb3-70c0dcbdd32f)
![image](https://github.com/user-attachments/assets/3df42955-3fdb-43be-b143-3153f668557b)
![image](https://github.com/user-attachments/assets/bf04d5c2-1806-4ab1-91c1-125b3e05a36d)


## quản lý dịch vụ
![image](https://github.com/user-attachments/assets/85c0438b-29c5-438c-bdf3-07b3d654c0d0)
![image](https://github.com/user-attachments/assets/4f8e4ef8-6bcf-4a47-aae6-f5268a8e8358)
![image](https://github.com/user-attachments/assets/6ef76a8f-206d-42b8-a869-b01c84450089)


## quản lý hóa đơn
![image](https://github.com/user-attachments/assets/e423a4be-58ef-45ac-ae25-6f3123556e46)
![image](https://github.com/user-attachments/assets/9890e588-8a9a-424e-b492-42384bdd93d1)
![image](https://github.com/user-attachments/assets/5cc36533-cfb3-47c1-9acb-0afcfd8b6590)



## quản lý khách hàng

![image](https://github.com/user-attachments/assets/6d0e582f-d05e-466a-8fd6-a184b1b86544)
![image](https://github.com/user-attachments/assets/e1a1f1ed-6967-4073-acec-0756102e8574)
![image](https://github.com/user-attachments/assets/49a09efe-a6b9-4e36-9162-2b24a9415984)



## quản lý nhân viên
![image](https://github.com/user-attachments/assets/13710251-9047-4c6d-a386-ae94432c04c9)
![image](https://github.com/user-attachments/assets/530f127f-f2e7-4993-a64a-fd2f310703d8)
![image](https://github.com/user-attachments/assets/371e1fc5-2235-4546-86e8-4b24e76a8b91)



## quản lý loại tài khoản
![image](https://github.com/user-attachments/assets/417f06f9-4140-4df6-b701-2740d68b82c1)

![image](https://github.com/user-attachments/assets/0e439748-3673-45e1-a541-a9399c1ed3fe)
![image](https://github.com/user-attachments/assets/3e0e6bea-a0db-4797-a9a4-54bf1df2fb68)
![image](https://github.com/user-attachments/assets/3990da22-4344-4b41-b1a1-a881c5ed9131)
![image](https://github.com/user-attachments/assets/43366e84-c2be-4c73-b6b8-f285726d8250)

# giao diện khi khách hàng login

![image](https://github.com/user-attachments/assets/502d0aaa-c792-4d68-9ead-8812c6553e05)

Đặt phòng trước
![image](https://github.com/user-attachments/assets/3d2ef487-f7b8-4eaf-b716-f3fdb1348d91)
![image](https://github.com/user-attachments/assets/ea8ca145-6efd-480d-b95c-7ed565215bd4)
![image](https://github.com/user-attachments/assets/2e4bd20f-f0ca-423a-9bd0-e955af223981)

## xem phòng đã đặt
![image](https://github.com/user-attachments/assets/9b3619a0-4bae-4bb4-ab49-c4f343106000)
![image](https://github.com/user-attachments/assets/7fd092f1-7d89-4a31-9e64-43c80660ec4f)































