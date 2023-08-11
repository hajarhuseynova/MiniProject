const open = document.getElementById("burger");
const menu = document.getElementById("menu");
const close = document.getElementById("sidebarDelete");
const visible = document.querySelectorAll(".visible");
const sidebar = document.getElementById("navbar_bottom");

document.body.addEventListener("click", () => {
  open.style.display = "block";
  close.style.display = "none";
  visible.forEach((element) => {
    element.style.marginLeft = "-15000px";
  });
  sidebar.style.width = "0";
});
open.addEventListener("click", (e) => {
  open.style.display = "none";
  close.style.display = "block";
  visible.forEach((element) => {
    element.style.marginLeft = "0";
  });
  sidebar.style.width = "100%";
  e.stopPropagation();
});

menu.addEventListener("click", (e) => {
  open.style.display = "none";
  close.style.display = "block";
  visible.forEach((element) => {
    element.style.marginLeft = "0";
  });
  sidebar.style.width = "100%";
  e.stopPropagation();
});
