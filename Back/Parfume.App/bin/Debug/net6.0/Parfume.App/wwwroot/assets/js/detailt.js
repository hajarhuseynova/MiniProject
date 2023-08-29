const min = document.getElementById("low");
const pil = document.getElementById("high");
const inputValu = document.getElementById("countInputSmoke");

min.addEventListener("click", () => {
  if (inputValue.value > 0) {
    inputValu.value = parseInt(inputValu.value) - 1;
  }
});

pil.addEventListener("click", () => {
  inputValu.value = parseInt(inputValu.value) + 1;
});

function increaseLike(element) {
  var likeCountElement = element.nextElementSibling;
  var currentLikeCount = parseInt(likeCountElement.textContent);
  likeCountElement.textContent = currentLikeCount + 1;
}
function decreaseDislike(element) {
  var dislikeCountElement = element.nextElementSibling;
  var currentDislikeCount = parseInt(dislikeCountElement.textContent);

  if (currentDislikeCount > 0) {
    dislikeCountElement.textContent = currentDislikeCount - 1;
  }
}
