class block{
  constructor(rect, unique_id, class_id) {
   this.rect = rect;
   this.Left_Wall = rect.left;
   this.Right_Wall = rect.right;
   this.Top_Wall = rect.top;
   this.Bottom_Wall = rect.bottom;
   this.unique_id = unique_id;
   this.class = class_id;
   console.log(this.class);
 }


}
