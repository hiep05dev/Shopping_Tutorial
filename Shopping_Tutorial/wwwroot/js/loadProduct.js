// Hàm để tải danh sách sản phẩm từ API
async function loadProductsByBrand() {
    try {
        // Gọi API để lấy sản phẩm theo brand
        const response = await fetch('http://localhost:5133/api/products/by-brand'); // Đảm bảo URL chính xác
        if (!response.ok) throw new Error('Lỗi khi gọi API');

        // Chuyển dữ liệu trả về thành JSON
        const products = await response.json();

        // Lấy container để hiển thị danh sách sản phẩm
        const productContainer = document.getElementById('productContainer');
        productContainer.innerHTML = ''; // Xóa nội dung cũ trước khi hiển thị

        // Duyệt qua danh sách sản phẩm và thêm vào HTML
        products.forEach(product => {
            const productHtml = `
                    <div class="col-sm-4">
                        <div class="product-image-wrapper">
                            <div class="single-products">
                                <div class="productinfo text-center">
                                    <img src="/images/${product.imgae}" alt="${product.name}" style="width: 200px; height: 200px; object-fit: cover;" />
                                    <h2>${product.price.toLocaleString()} VND</h2>
                                    <p>${product.name}</p>
                                    <p>Thương hiệu: ${product.brand.name}</p>
                                    <p>Mô tả: ${product.description}</p>
                                    <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                </div>
                            </div>
                        </div>
                    </div>
                `;
            // Thêm sản phẩm vào container
            productContainer.innerHTML += productHtml;
        });
    } catch (error) {
        console.error('Error:', error);
        alert('Không thể tải sản phẩm, vui lòng thử lại!');
    }
}

// Gắn sự kiện click cho nút "Apple"
document.getElementById('appleButton').addEventListener('click', function (event) {
    event.preventDefault(); // Ngừng hành động mặc định của nút
    loadProductsByBrand(); // Gọi hàm tải sản phẩm
});