Để sử dụng nhanh UnMask, chuột phải vào Hierachy->UI->UnMask hoặc UnMask_WithUIMask.
Để tạo được bằng cách này thì trên scene phải có canvas.

Lưu ý khi sử dụng 2 UnMask hoặc UnMask_WithUIMask.
-UnMask không yêu cầu quan hệ cha con như mask bình thường của Unity. UnMask hiện tại không hỗ trợ mask lồng nhau, và việc hiển thì nhiều cặp UnMask 
cùng lúc trên scene vẫn được nhưng có thể gây lỗi hình ảnh. (Thông thường chỉ cần dùng 1 cặp để làm vài hiệu ứng đặc biệt).
-UnMask linh hoạt trong việc có thể di chuyển khắp nơi do không bị ràng buộc bởi quan hệ cha con. Raycast có thể bắn xuyên qua vùng được đục lỗ và bị chặn ở vùng không bị đục.
-Thích hợp để làm hiệu ứng xuyên tường, tutorial,open scene hoặc close scene,....

- UnMask_WithUIMask là sử dụng UnMask bằng thành phần mask trên UI của Unity, hỗ trợ việc hiển thị nhiều cặp UnMask mà không bị lỗi hình ảnh
tuy nhiên trong pack này thì raycast sẽ bắn xuyên qua UnMask_WithUIMask.