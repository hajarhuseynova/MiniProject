const minus = document.getElementById("low");
const pilus = document.getElementById("high");
const inputValue = document.getElementById("countInputSmoke");

minus.addEventListener("click", () => {
  if (inputValue.value > 0) {
    inputValue.value = parseInt(inputValue.value) - 1;
  }
});

pilus.addEventListener("click", () => {
  inputValue.value = parseInt(inputValue.value) + 1;
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
