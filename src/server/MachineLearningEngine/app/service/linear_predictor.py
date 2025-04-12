import joblib
import numpy as np
import os

model_path = os.path.join(os.path.dirname(__file__), '../models/trained/home_rent_lr.pkl')
model = joblib.load(model_path)

def predict_rent(data):
    features = np.array([[data['beds'],data['bath'],data['area'],data['address'],data['type']]])
    prediction = model.predict(features)
    return round(abs(prediction[0]), 2)