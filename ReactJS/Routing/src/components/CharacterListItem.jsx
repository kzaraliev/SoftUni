import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import { Link } from "react-router-dom";
import { normalizeName } from "../utils/characterUtils";

export default function CharacterListItem({
  id,
  name,
  hair_color,
  eye_color,
  birth_year,
  gender,
}) {
  return (
    <Card style={{ width: "18rem" }}>
      <Card.Body>
        <Card.Title>{name}</Card.Title>
        <Card.Text>
          <ul>
            <li>hair color: {hair_color}</li>
            <li>eye color: {eye_color}</li>
            <li>birth year: {birth_year}</li>
            <li>gender: {gender}</li>
          </ul>
        </Card.Text>
        <Button as={Link} to={`/characters/${id}`} variant="primary">
          Details
        </Button>
      </Card.Body>
    </Card>
  );
}
