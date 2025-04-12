from flask import Blueprint, jsonify, request
from services.linear_predictor import predict_rent

property_bp = Blueprint('property', __name__)

@property_bp.route('/property-price', methods=['POST'])
def predict_property_price():
    data = request.get_json()
    if not data:
        return jsonify({"error": "Invalid input"}), 400

    # Validate input data
    required_fields = ['beds', 'bath', 'area', 'address', 'type']
    for field in required_fields:
        if field not in data:
            return jsonify({"error": f"Missing field: {field}"}), 400

    try:
        prediction = predict_rent(data)
        return jsonify({"predicted_price": prediction}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500